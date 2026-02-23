using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WorkforceConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<WorkforceDisplayModel, WorkforceDisplayModel, Models.Page.Configuration.WorkforceConfigurationPageModel>
{
    private readonly List<WorkforceOrganizationalUnitInputModel> editionOrganizationalUnits = [];
    private readonly List<WorkforceOrganizationalUnitInputModel> incomingOrganizationalUnits = [];
    private readonly List<WorkforceOrganizationalUnitDisplayModel> outgoingOrganizationalUnits = [];

    public WorkforceConfigurationPage(System.Action<WorkforceDisplayModel> successAction, Models.Page.Configuration.WorkforceConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.WorkforceConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }
    
    protected override string EntityTypeName => "Estructura de Plantilla";

    protected override async System.Threading.Tasks.Task<WorkforceDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WorkforcesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new WorkforceInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            At = ConcreteBindingContext.At,
            Priority = ConcreteBindingContext.Priority,
            OrganizationalStructureId = ConcreteBindingContext.OrganizationalStructure.Id,
            IncomingOrganizationalUnits = incomingOrganizationalUnits
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<WorkforceDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WorkforcesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new WorkforceInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            At = ConcreteBindingContext.At,
            Priority = ConcreteBindingContext.Priority,
            OrganizationalStructureId = ConcreteBindingContext.OrganizationalStructure.Id,
            IncomingOrganizationalUnits = incomingOrganizationalUnits,
            EditionOrganizationalUnits = editionOrganizationalUnits,
            OutgoingOrganizationalUnits = outgoingOrganizationalUnits
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void AddOrganizationalUnityButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.OrganizationalUnitPickPage(OrganizationalUnityPickComplete_Callback)));
    }

    private void OrganizationalUnityRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta unidad organizativa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalStructuringUnitTreeViewModel;

            var handled = false;

            foreach (var item in incomingOrganizationalUnits)
            {
                if (item.Id != target.Id) continue;

                incomingOrganizationalUnits.Remove(incomingOrganizationalUnits.First(model => model.Id == target.Id));

                handled = true;

                break;
            }

            if (!handled)
            {
                foreach (var item in editionOrganizationalUnits)
                {
                    if (item.Id != target.Id) continue;

                    editionOrganizationalUnits.Remove(editionOrganizationalUnits.First(model => model.Id == target.Id));

                    break;
                }
            }

            if (!handled)
            {
                outgoingOrganizationalUnits.Add(new WorkforceOrganizationalUnitDisplayModel
                {
                    Id = target.Id
                });
            }

            hasChangesFlag = true;

            //Dispatcher.Dispatch(() => ((Models.Page.Configuration.WorkforceConfigurationPageModel)BindingContext).OrganizationalUnities.Remove(target));
        });
    }

    private void DefineChiefVacantButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Models.View.WorkforceConfigurationVacantViewModel, Models.Page.Configuration.VacantConfigurationPageModel>>();

                var page = await factory.BuildAsync(ChiefVacantDefineSuccess_Callback, null);

                page.ConcreteBindingContext.OrganizationUnity = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalStructuringUnitTreeViewModel;

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(page);
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void AddVacantButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Models.View.WorkforceConfigurationVacantViewModel, Models.Page.Configuration.VacantConfigurationPageModel>>();

                var page = await factory.BuildAsync(VacantCreateSuccess_Callback, null);

                page.ConcreteBindingContext.OrganizationUnity = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalStructuringUnitTreeViewModel;

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(page);
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void ChiefVacantEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Models.View.WorkforceConfigurationVacantViewModel, Models.Page.Configuration.VacantConfigurationPageModel>>();

                var page = await factory.BuildAsync(ChiefVacantEditSuccess_Callback, (((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalStructuringUnitTreeViewModel).ChiefVacant);

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(page);
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void VacantEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Models.View.WorkforceConfigurationVacantViewModel, Models.Page.Configuration.VacantConfigurationPageModel>>();

                var page = await factory.BuildAsync(VacantEditSuccess_Callback, ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationVacantViewModel);

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(page);
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void VacantRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta vacante?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationVacantViewModel;

            var target = WorkforceConfigurationPage.FindTargetWorkforceOrganizationalUnit(model, incomingOrganizationalUnits, editionOrganizationalUnits);

            Dispatcher.Dispatch(() =>
            {
                if (target != null)
                {
                    var handled = false;

                    foreach (var item in target.IncomingVacants)
                    {
                        if (item.Id != model.Id) continue;

                        target.IncomingVacants.Remove(target.IncomingVacants.First(_model => _model.Id == model.Id));

                        handled = true;

                        break;
                    }

                    if (!handled)
                    {
                        foreach (var item in target.EditionVacants)
                        {
                            if (item.Id != model.Id) continue;

                            target.EditionVacants.Remove(target.EditionVacants.First(_model => _model.Id == model.Id));

                            break;
                        }
                    }

                    if (!handled)
                    {
                        target.OutgoingVacants.Add(new VacantDisplayModel
                        {
                            Id = model.Id
                        });
                    }
                }
                else
                {
                    editionOrganizationalUnits.Add(new WorkforceOrganizationalUnitInputModel
                    {
                        Id = model.Context.Id,
                        OrganizationalStructuringUnityId = model.Context.Context.Id,
                        OutgoingVacants = [new VacantDisplayModel
                        {
                            Id = model.Id
                        }]
                    });
                }

                model.Context.Vacants.Remove(model);

                hasChangesFlag = true;
            });
        });
    }

    private void OrganizationalUnityPickComplete_Callback(Domain.Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel model)
    {
        var apiConnectClient = new Domain.Interop.API.Connect.Clients.OrganizationalUnitsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.WorkforceConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        apiConnectClient.GetAsync(model.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                concreteBindingContext.IsBusy = false;

                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var model = new WorkforceOrganizationalUnitInputModel
                    {
                        Id = System.Guid.NewGuid(),
                        //OrganizationalUnityId = task.Result.Id                        
                    };

                    //((Models.Page.Configuration.WorkforceConfigurationPageModel)BindingContext).OrganizationalUnities.Add(new Models.View.WorkforceConfigurationOrganizationalStructuringUnitTreeViewModel
                    //{
                    //    Id = model.Id,
                        //Domain = task.Result,
                        //Children = GetOrganizationalUnityChildren(task.Result, model)
                    //});

                    incomingOrganizationalUnits.Add(model);

                    hasChangesFlag = true;
                }
            });
        });
    }

    private void ChiefVacantDefineSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var target = WorkforceConfigurationPage.FindTargetWorkforceOrganizationalUnit(model, incomingOrganizationalUnits, editionOrganizationalUnits);

        if (target != null)
        {
            target.ChiefVacant = new VacantInputModel
            {
                Id = model.Id,
                OcupationMode = model.OcupationMode,
                Priority = model.Priority,
                SalaryStandardId = model.SalaryStandard.Id,
                WorkPositionId = model.WorkPosition.Id,
                WorkforceOrganizationalUnitId = model.Context.Id
            };
        }
        else
        {
            editionOrganizationalUnits.Add(new WorkforceOrganizationalUnitInputModel
            {
                Id = model.Context.Id,
                OrganizationalStructuringUnityId = model.Context.Context.Id,
                ChiefVacant = new VacantInputModel
                {
                    Id = model.Id,
                    OcupationMode = model.OcupationMode,
                    Priority = model.Priority,
                    SalaryStandardId = model.SalaryStandard.Id,
                    WorkPositionId = model.WorkPosition.Id,
                    WorkforceOrganizationalUnitId = model.Context.Id
                }
            });
        }

        model.Context.ChiefVacant = model;

        hasChangesFlag = true;
    }

    private void VacantCreateSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var target = WorkforceConfigurationPage.FindTargetWorkforceOrganizationalUnit(model, incomingOrganizationalUnits, editionOrganizationalUnits);

        if (target != null)
        {
            target.IncomingVacants.Add(new VacantInputModel
            {
                Id = model.Id,
                OcupationMode = model.OcupationMode,
                Priority = model.Priority,
                SalaryStandardId = model.SalaryStandard.Id,
                WorkPositionId = model.WorkPosition.Id,
                WorkforceOrganizationalUnitId = model.Context.Id
            });
        }
        else
        {
            editionOrganizationalUnits.Add(new WorkforceOrganizationalUnitInputModel
            {
                Id = model.Context.Id,
                OrganizationalStructuringUnityId = model.Context.Context.Id,
                IncomingVacants = [new VacantInputModel
                {
                    Id = model.Id,
                    OcupationMode = model.OcupationMode,
                    Priority = model.Priority,
                    SalaryStandardId = model.SalaryStandard.Id,
                    WorkPositionId = model.WorkPosition.Id,
                    WorkforceOrganizationalUnitId = model.Context.Id
                }]
            });
        }

        model.Context.Vacants.Add(model);

        hasChangesFlag = true;
    }

    private void ChiefVacantEditSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var target = WorkforceConfigurationPage.FindTargetWorkforceOrganizationalUnit(model, incomingOrganizationalUnits, editionOrganizationalUnits);

        target.ChiefVacant.Priority = model.Priority;
        target.ChiefVacant.OcupationMode = model.OcupationMode;
        target.ChiefVacant.WorkforceOrganizationalUnitId = model.Context.Id;
        target.ChiefVacant.WorkPositionId = model.WorkPosition.Id;
        target.ChiefVacant.SalaryStandardId = model.SalaryStandard.Id;

        model.Context.ChiefVacant.Priority = model.Priority;
        model.Context.ChiefVacant.OcupationMode = model.OcupationMode;
        model.Context.ChiefVacant.Context = model.Context;
        model.Context.ChiefVacant.WorkPosition = model.WorkPosition;
        model.Context.ChiefVacant.SalaryStandard = model.SalaryStandard;

        hasChangesFlag = true;
    }

    private void VacantEditSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var target = WorkforceConfigurationPage.FindTargetWorkforceOrganizationalUnit(model, incomingOrganizationalUnits, editionOrganizationalUnits);

        if (target != null)
        {
            var handled = false;

            foreach (var item in target.IncomingVacants)
            {
                if (item.Id != model.Id) continue;

                item.OcupationMode = model.OcupationMode;
                item.Priority = model.Priority;
                item.SalaryStandardId = model.SalaryStandard.Id;
                item.WorkPositionId = model.WorkPosition.Id;

                handled = true;
            }

            if (!handled)
            {
                foreach (var item in target.EditionVacants)
                {
                    if (item.Id != model.Id) continue;

                    item.OcupationMode = model.OcupationMode;
                    item.Priority = model.Priority;
                    item.SalaryStandardId = model.SalaryStandard.Id;
                    item.WorkPositionId = model.WorkPosition.Id;

                    handled = true;
                }
            }

            if (!handled)
            {
                target.IncomingVacants.Add(new VacantInputModel
                {
                    Id = model.Id,
                    OcupationMode = model.OcupationMode,
                    Priority = model.Priority,
                    SalaryStandardId = model.SalaryStandard.Id,
                    WorkPositionId = model.WorkPosition.Id,
                    WorkforceOrganizationalUnitId = model.Context.Id
                });
            }
        }
        else
        {
            editionOrganizationalUnits.Add(new WorkforceOrganizationalUnitInputModel
            {
                Id = model.Context.Id,
                OrganizationalStructuringUnityId = model.Context.Context.Id,
                EditionVacants = [new VacantInputModel
                {
                    Id = model.Id,
                    OcupationMode = model.OcupationMode,
                    Priority = model.Priority,
                    SalaryStandardId = model.SalaryStandard.Id,
                    WorkPositionId = model.WorkPosition.Id,
                    WorkforceOrganizationalUnitId = model.Context.Id
                }]
            });
        }

        var index = -1;

        foreach (var item in model.Context.Vacants)
        {
            index++;

            if (item.Id != model.Id) continue;

            model.Context.Vacants[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    //private static Models.View.WorkforceConfigurationOrganizationalStructuringUnitViewModel[] GetOrganizationalUnityChildren(Domain.Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel target, WorkforceOrganizationalUnitInputModel model)
    //{
    //    var result = new List<Models.View.WorkforceConfigurationOrganizationalStructuringUnitViewModel>();

        //foreach (var item in target.Children)
        //{
        //    var _model = new WorkforceOrganizationalUnityInputModel
        //    {
        //        Id = System.Guid.NewGuid(),
        //        OrganizationalUnityId = item.Id
        //    };

        //    var _target = new Models.View.WorkforceConfigurationOrganizationalUnityViewModel
        //    {
        //        Id = _model.Id,
        //        Domain = item
        //    };

        //    if (item.Children != null)
        //    {
        //        _target.Children = GetOrganizationalUnityChildren(item, _model);
        //    }

        //    result.Add(_target);

        //    model.Children.Add(_model);
        //}

    //    return [.. result];
    //}

    private static WorkforceOrganizationalUnitInputModel FindTargetWorkforceOrganizationalUnit(Models.View.WorkforceConfigurationVacantViewModel model, List<WorkforceOrganizationalUnitInputModel> incomingOrganizationalUnits, List<WorkforceOrganizationalUnitInputModel> editionOrganizationalUnits)
    {
        if (incomingOrganizationalUnits.Count <= 0 && editionOrganizationalUnits.Count <= 0) return null;

        foreach (var item in incomingOrganizationalUnits)
        {
            if (item.Id != model.Context.Id) continue;

            return item;
        }

        foreach (var item in editionOrganizationalUnits)
        {
            if (item.Id != model.Context.Id) continue;

            return item;
        }

        //foreach (var item in incomingOrganizationalUnits)
        //{
        //    var result = FindTargetWorkforceOrganizationalUnity(model, item.Children, []);

        //    if (result != null) return result;
        //}

        //foreach (var item in editionOrganizationalUnits)
        //{
        //    var result = FindTargetWorkforceOrganizationalUnity(model, [], item.Children);

        //    if (result != null) return result;
        //}

        return null;
    }
}