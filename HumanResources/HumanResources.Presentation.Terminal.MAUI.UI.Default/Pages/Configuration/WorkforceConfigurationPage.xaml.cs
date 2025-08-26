using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WorkforceConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<WorkforceDisplayModel, WorkforceDisplayModel, Models.Page.Configuration.WorkforceConfigurationPageModel>
{
    private readonly List<VacantInputModel> editionVacants = [];
    private readonly List<VacantInputModel> incomingVacants = [];
    private readonly List<VacantDisplayModel> outgoingVacants = [];

    public WorkforceConfigurationPage(System.Action<WorkforceDisplayModel> successAction, Models.Page.Configuration.WorkforceConfigurationPageModel model) : base(successAction, model)
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
            OrganizationalUnities = ConcreteBindingContext.OrganizationalUnities.Select(_model => new Domain.Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel { Id = _model.Id }).ToList(),
            IncomingVacants = incomingVacants
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
            OrganizationalUnities = ConcreteBindingContext.OrganizationalUnities.Select(_model => new Domain.Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel { Id = _model.Id }).ToList(),
            IncomingVacants = incomingVacants,
            EditionVacants = editionVacants,
            OutgoingVacants = outgoingVacants
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.OrganizationalUnityPickPage(OrganizationalUnityPickComplete_Callback)));
    }

    private void OrganizationalUnityRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta unidad organizativa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalUnityViewModel;

            incomingVacants.RemoveAll(model => model.OrganizationUnityId == target.Id);
            editionVacants.RemoveAll(model => model.OrganizationUnityId == target.Id);
            outgoingVacants.RemoveAll(model => model.OrganizationUnityId == target.Id);

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.WorkforceConfigurationPageModel)BindingContext).OrganizationalUnities.Remove(target));
        });
    }

    private void AddVacantButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var workPositionsAPIConnectClient = new Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
                var salaryStandardsAPIConnectClient = new Interop.API.Connect.Clients.SalaryStandardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.VacantConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationOrganizationalUnityViewModel)
                {
                    AvailableWorkPositions = await workPositionsAPIConnectClient.GetAsync(),
                    AvailableSalaryStandards = await salaryStandardsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Configuration.VacantConfigurationPage(VacantCreateSuccess_Callback, model));
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

        System.Threading.Tasks.Task.Run((System.Func<System.Threading.Tasks.Task>)(async () =>
        {
            try
            {
                var workPositionsAPIConnectClient = new Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
                var salaryStandardsAPIConnectClient = new Interop.API.Connect.Clients.SalaryStandardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.VacantConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationVacantViewModel)
                {
                    AvailableWorkPositions = await workPositionsAPIConnectClient.GetAsync(),
                    AvailableSalaryStandards = await salaryStandardsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch((System.Action)(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync((Microsoft.Maui.Controls.Page)new Configuration.VacantConfigurationPage(VacantEditSuccess_Callback, model));
                }));
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        }));
    }

    private void VacantRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta vacante?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.WorkforceConfigurationVacantViewModel;

                var handled = false;

                foreach (var item in incomingVacants)
                {
                    if (item.Id != target.Id) continue;

                    incomingVacants.Remove(incomingVacants.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionVacants)
                    {
                        if (item.Id != target.Id) continue;

                        editionVacants.Remove(editionVacants.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingVacants.Add(new VacantDisplayModel
                    {
                        Id = target.Id                        
                    });
                }

                target.OrganizationUnity.Vacants.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void OrganizationalUnityPickComplete_Callback(Domain.Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel model)
    {
        var apiConnectClient = new Domain.Interop.API.Connect.Clients.TreeOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
                    ((Models.Page.Configuration.WorkforceConfigurationPageModel)BindingContext).OrganizationalUnities.Add(new Models.View.WorkforceConfigurationOrganizationalUnityViewModel
                    {
                        Id = task.Result.Id,
                        Name = task.Result.Name,
                        Enabled = task.Result.Enabled,
                        Priority = task.Result.Priority,
                        Reference = task.Result.Reference,
                        Children = GetOrganizationalUnityChildren(task.Result)
                    });

                    hasChangesFlag = true;
                }
            });
        });
    }

    private void VacantCreateSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        incomingVacants.Add(new VacantInputModel
        {
            Id = model.Id,
            OcupationMode = model.OcupationMode,
            Priority = model.Priority,
            OrganizationUnityId = model.OrganizationUnity.Id,
            WorkPositionId = model.WorkPosition.Id,
            SalaryStandardId = model.SalaryStandard.Id
        });

        model.OrganizationUnity.Vacants.Add(model);
    }

    private void VacantEditSuccess_Callback(Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var handled = false;

        foreach (var item in incomingVacants)
        {
            if (item.Id != model.Id) continue;

            item.Priority = model.Priority;
            item.OcupationMode = model.OcupationMode;
            item.OrganizationUnityId = model.OrganizationUnity.Id;
            item.WorkPositionId = model.WorkPosition.Id;
            item.SalaryStandardId = model.SalaryStandard.Id;

            handled = true;
        }

        if (!handled)
        {
            foreach (var item in editionVacants)
            {
                if (item.Id != model.Id) continue;

                item.Priority = model.Priority;
                item.OcupationMode = model.OcupationMode;
                item.OrganizationUnityId = model.OrganizationUnity.Id;
                item.WorkPositionId = model.WorkPosition.Id;
                item.SalaryStandardId = model.SalaryStandard.Id;

                handled = true;
            }
        }

        if (!handled)
        {
            editionVacants.Add(new VacantInputModel
            {
                Id = model.Id,
                OcupationMode = model.OcupationMode,
                Priority = model.Priority,
                OrganizationUnityId = model.OrganizationUnity.Id,
                WorkPositionId = model.WorkPosition.Id,
                SalaryStandardId = model.SalaryStandard.Id
            });
        }

        foreach (var item in model.OrganizationUnity.Vacants)
        {
            if (item.Id != model.Id) continue;

            item.Priority = model.Priority;
            item.OcupationMode = model.OcupationMode;
            item.WorkPosition = model.WorkPosition;
            item.SalaryStandard = model.SalaryStandard;
        }
    }

    private static Models.View.WorkforceConfigurationOrganizationalUnityViewModel[] GetOrganizationalUnityChildren(Domain.Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel model)
    {
        var result = new List<Models.View.WorkforceConfigurationOrganizationalUnityViewModel>();

        foreach (var item in model.Children)
        {
            var _model = new Models.View.WorkforceConfigurationOrganizationalUnityViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Enabled = item.Enabled,
                Priority = item.Priority,
                Reference = item.Reference
            };

            if (item.Children != null)
            {
                _model.Children = GetOrganizationalUnityChildren(item);
            }

            result.Add(_model);
        }

        return [.. result];
    }
}