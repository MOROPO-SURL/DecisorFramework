using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WorkforceConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<WorkforceDisplayModel, WorkforceDisplayModel, Models.Page.Configuration.WorkforceConfigurationPageModel>
{
    private readonly List<WorkforceOrganizationalUnityInputModel> editionOrganizationalUnities = [];
    private readonly List<WorkforceOrganizationalUnityInputModel> incomingOrganizationalUnities = [];
    private readonly List<WorkforceOrganizationalUnityDisplayModel> outgoingOrganizationalUnities = [];

    public WorkforceConfigurationPage(System.Action<WorkforceDisplayModel> successAction, Models.Page.Configuration.WorkforceConfigurationPageModel model) : base(successAction, model, null)
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
            ChiefVacant = new VacantInputModel
            {
                Id = ConcreteBindingContext.ChiefVacant.Id,
                Priority = ConcreteBindingContext.ChiefVacant.Priority,
                OcupationMode = ConcreteBindingContext.ChiefVacant.OcupationMode,
                SalaryStandardId = ConcreteBindingContext.ChiefVacant.SalaryStandard.Id,
                WorkPositionId = ConcreteBindingContext.ChiefVacant.WorkPosition.Id
            },
            IncomingOrganizationalUnities = incomingOrganizationalUnities
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
            ChiefVacant = new VacantInputModel
            {
                Id = ConcreteBindingContext.ChiefVacant.Id,
                Priority = ConcreteBindingContext.ChiefVacant.Priority,
                OcupationMode = ConcreteBindingContext.ChiefVacant.OcupationMode,
                SalaryStandardId = ConcreteBindingContext.ChiefVacant.SalaryStandard.Id,
                WorkPositionId = ConcreteBindingContext.ChiefVacant.WorkPosition.Id
            },
            IncomingOrganizationalUnities = incomingOrganizationalUnities,
            EditionOrganizationalUnities = editionOrganizationalUnities,
            OutgoingOrganizationalUnities = outgoingOrganizationalUnities
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

    private void AddOrganizationalUnityButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.OrganizationalUnitPickPage(OrganizationalUnityPickComplete_Callback)));
    }

    private void OrganizationalUnityRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta unidad organizativa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalUnityViewModel;

            var handled = false;

            foreach (var item in incomingOrganizationalUnities)
            {
                if (item.Id != target.Id) continue;

                incomingOrganizationalUnities.Remove(incomingOrganizationalUnities.First(model => model.Id == target.Id));

                handled = true;

                break;
            }

            if (!handled)
            {
                foreach (var item in editionOrganizationalUnities)
                {
                    if (item.Id != target.Id) continue;

                    editionOrganizationalUnities.Remove(editionOrganizationalUnities.First(model => model.Id == target.Id));

                    break;
                }
            }

            if (!handled)
            {
                outgoingOrganizationalUnities.Add(new WorkforceOrganizationalUnityDisplayModel
                {
                    Id = target.Id
                });
            }

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.WorkforceConfigurationPageModel)BindingContext).OrganizationalUnities.Remove(target));
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

                page.ConcreteBindingContext.OrganizationUnity = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalUnityViewModel;

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

                page.ConcreteBindingContext.OrganizationUnity = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalUnityViewModel;

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

    private void RootChiefVacantEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Models.View.WorkforceConfigurationVacantViewModel, Models.Page.Configuration.VacantConfigurationPageModel>>();

                var page = await factory.BuildAsync(ChiefVacantEditSuccess_Callback, new Models.View.WorkforceConfigurationVacantViewModel
                {
                    Id = ConcreteBindingContext.ChiefVacant.Id,
                    OcupationMode = ConcreteBindingContext.ChiefVacant.OcupationMode,
                    SalaryStandard = ConcreteBindingContext.ChiefVacant.SalaryStandard,
                    WorkPosition = ConcreteBindingContext.ChiefVacant.WorkPosition,
                    Priority = ConcreteBindingContext.ChiefVacant.Priority
                });

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

                var page = await factory.BuildAsync(ChiefVacantEditSuccess_Callback, (((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalUnityViewModel).ChiefVacant);

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

            var target = FindTargetWorkforceOrganizationalUnity(model, incomingOrganizationalUnities, editionOrganizationalUnities);

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
                    editionOrganizationalUnities.Add(new WorkforceOrganizationalUnityInputModel
                    {
                        Id = model.OrganizationUnity.Id,
                        OrganizationalUnityId = model.OrganizationUnity.Domain.Id,
                        OutgoingVacants = [new VacantDisplayModel
                        {
                            Id = model.Id
                        }]
                    });
                }

                model.OrganizationUnity.Vacants.Remove(model);

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
                    var model = new WorkforceOrganizationalUnityInputModel
                    {
                        Id = System.Guid.NewGuid(),
                        //OrganizationalUnityId = task.Result.Id                        
                    };

                    ((Models.Page.Configuration.WorkforceConfigurationPageModel)BindingContext).OrganizationalUnities.Add(new Models.View.WorkforceConfigurationOrganizationalUnityViewModel
                    {
                        Id = model.Id,
                        //Domain = task.Result,
                        //Children = GetOrganizationalUnityChildren(task.Result, model)
                    });

                    incomingOrganizationalUnities.Add(model);

                    hasChangesFlag = true;
                }
            });
        });
    }

    private void ChiefVacantDefineSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        if (model.OrganizationUnity == null)
        {
            ConcreteBindingContext.ChiefVacant = new Models.View.WorkforceConfigurationVacantViewModel
            {
                Id = model.Id,
                OcupationMode = model.OcupationMode,
                Priority = model.Priority,
                SalaryStandard = model.SalaryStandard,
                WorkPosition = model.WorkPosition
            };
        }
        else
        {
            var target = FindTargetWorkforceOrganizationalUnity(model, incomingOrganizationalUnities, editionOrganizationalUnities);

            if (target != null)
            {
                target.ChiefVacant = new VacantInputModel
                {
                    Id = model.Id,
                    OcupationMode = model.OcupationMode,
                    Priority = model.Priority,
                    SalaryStandardId = model.SalaryStandard.Id,
                    WorkPositionId = model.WorkPosition.Id,
                    WorkforceOrganizationalUnityId = model.OrganizationUnity.Id
                };
            }
            else
            {
                editionOrganizationalUnities.Add(new WorkforceOrganizationalUnityInputModel
                {
                    Id = model.OrganizationUnity.Id,
                    OrganizationalUnityId = model.OrganizationUnity.Domain.Id,
                    ChiefVacant = new VacantInputModel
                    {
                        Id = model.Id,
                        OcupationMode = model.OcupationMode,
                        Priority = model.Priority,
                        SalaryStandardId = model.SalaryStandard.Id,
                        WorkPositionId = model.WorkPosition.Id,
                        WorkforceOrganizationalUnityId = model.OrganizationUnity.Id
                    }
                });
            }

            model.OrganizationUnity.ChiefVacant = model;
        }

        hasChangesFlag = true;
    }

    private void VacantCreateSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var target = FindTargetWorkforceOrganizationalUnity(model, incomingOrganizationalUnities, editionOrganizationalUnities);

        if (target != null)
        {
            target.IncomingVacants.Add(new VacantInputModel
            {
                Id = model.Id,
                OcupationMode = model.OcupationMode,
                Priority = model.Priority,
                SalaryStandardId = model.SalaryStandard.Id,
                WorkPositionId = model.WorkPosition.Id,
                WorkforceOrganizationalUnityId = model.OrganizationUnity.Id
            });
        }
        else
        {
            editionOrganizationalUnities.Add(new WorkforceOrganizationalUnityInputModel
            {
                Id = model.OrganizationUnity.Id,
                OrganizationalUnityId = model.OrganizationUnity.Domain.Id,
                IncomingVacants = [new VacantInputModel
                {
                    Id = model.Id,
                    OcupationMode = model.OcupationMode,
                    Priority = model.Priority,
                    SalaryStandardId = model.SalaryStandard.Id,
                    WorkPositionId = model.WorkPosition.Id,
                    WorkforceOrganizationalUnityId = model.OrganizationUnity.Id
                }]
            });
        }

        model.OrganizationUnity.Vacants.Add(model);

        hasChangesFlag = true;
    }

    private void ChiefVacantEditSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        if (model.OrganizationUnity == null)
        {
            ConcreteBindingContext.ChiefVacant.Priority = model.Priority;
            ConcreteBindingContext.ChiefVacant.OcupationMode = model.OcupationMode;
            ConcreteBindingContext.ChiefVacant.WorkPosition = model.WorkPosition;
            ConcreteBindingContext.ChiefVacant.SalaryStandard = model.SalaryStandard;
        }
        else
        {
            var target = FindTargetWorkforceOrganizationalUnity(model, incomingOrganizationalUnities, editionOrganizationalUnities);

            target.ChiefVacant.Priority = model.Priority;
            target.ChiefVacant.OcupationMode = model.OcupationMode;
            target.ChiefVacant.WorkforceOrganizationalUnityId = model.OrganizationUnity.Id;
            target.ChiefVacant.WorkPositionId = model.WorkPosition.Id;
            target.ChiefVacant.SalaryStandardId = model.SalaryStandard.Id;

            model.OrganizationUnity.ChiefVacant.Priority = model.Priority;
            model.OrganizationUnity.ChiefVacant.OcupationMode = model.OcupationMode;
            model.OrganizationUnity.ChiefVacant.OrganizationUnity = model.OrganizationUnity;
            model.OrganizationUnity.ChiefVacant.WorkPosition = model.WorkPosition;
            model.OrganizationUnity.ChiefVacant.SalaryStandard = model.SalaryStandard;
        }

        hasChangesFlag = true;
    }

    private void VacantEditSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var target = FindTargetWorkforceOrganizationalUnity(model, incomingOrganizationalUnities, editionOrganizationalUnities);

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
                    WorkforceOrganizationalUnityId = model.OrganizationUnity.Id
                });
            }
        }
        else
        {
            editionOrganizationalUnities.Add(new WorkforceOrganizationalUnityInputModel
            {
                Id = model.OrganizationUnity.Id,
                OrganizationalUnityId = model.OrganizationUnity.Domain.Id,
                EditionVacants = [new VacantInputModel
                {
                    Id = model.Id,
                    OcupationMode = model.OcupationMode,
                    Priority = model.Priority,
                    SalaryStandardId = model.SalaryStandard.Id,
                    WorkPositionId = model.WorkPosition.Id,
                    WorkforceOrganizationalUnityId = model.OrganizationUnity.Id
                }]
            });
        }

        var index = -1;

        foreach (var item in model.OrganizationUnity.Vacants)
        {
            index++;

            if (item.Id != model.Id) continue;

            model.OrganizationUnity.Vacants[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private static Models.View.WorkforceConfigurationOrganizationalUnityViewModel[] GetOrganizationalUnityChildren(Domain.Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel target, WorkforceOrganizationalUnityInputModel model)
    {
        var result = new List<Models.View.WorkforceConfigurationOrganizationalUnityViewModel>();

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

        return [.. result];
    }

    private WorkforceOrganizationalUnityInputModel FindTargetWorkforceOrganizationalUnity(Models.View.WorkforceConfigurationVacantViewModel model, List<WorkforceOrganizationalUnityInputModel> incomingOrganizationalUnities, List<WorkforceOrganizationalUnityInputModel> editionOrganizationalUnities)
    {
        if (incomingOrganizationalUnities.Count <= 0 && editionOrganizationalUnities.Count <= 0) return null;

        foreach (var item in incomingOrganizationalUnities)
        {
            if (item.Id != model.OrganizationUnity.Id) continue;

            return item;
        }

        foreach (var item in editionOrganizationalUnities)
        {
            if (item.Id != model.OrganizationUnity.Id) continue;

            return item;
        }

        foreach (var item in incomingOrganizationalUnities)
        {
            var result = FindTargetWorkforceOrganizationalUnity(model, item.Children, []);

            if (result != null) return result;
        }

        foreach (var item in editionOrganizationalUnities)
        {
            var result = FindTargetWorkforceOrganizationalUnity(model, [], item.Children);

            if (result != null) return result;
        }

        return null;
    }
}