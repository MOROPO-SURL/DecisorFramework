using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class OrganizationalStructureConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel, Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel, Models.Page.Configuration.OrganizationalStructureConfigurationPageModel>
{
    public OrganizationalStructureConfigurationPage(System.Action<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel> successAction, Models.Page.Configuration.OrganizationalStructureConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.OrganizationalStructureConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Estructura Organizacional";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationalStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.OrganizationalStructureInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Priority = ConcreteBindingContext.Priority,
            RootStructuringUnit = new Interop.API.Common.Models.Input.OrganizationalStructuringUnitInputModel
            {
                Id = ConcreteBindingContext.OrganizationalStructuringUnitConfiguration.Id,
                OrganizationalUnitId = ConcreteBindingContext.OrganizationalStructuringUnitConfiguration.OrganizationalUnit.Id,
                Reference = ConcreteBindingContext.OrganizationalStructuringUnitConfiguration.Reference
            },
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        DeepBind(model, ConcreteBindingContext.OrganizationalStructuringUnitConfiguration);

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationalStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.OrganizationalStructureInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Priority = ConcreteBindingContext.Priority,
            RootStructuringUnit = new Interop.API.Common.Models.Input.OrganizationalStructuringUnitInputModel
            {
                Id = ConcreteBindingContext.OrganizationalStructuringUnitConfiguration.Id,
                OrganizationalUnitId = ConcreteBindingContext.OrganizationalStructuringUnitConfiguration.OrganizationalUnit.Id,
                Reference = ConcreteBindingContext.OrganizationalStructuringUnitConfiguration.Reference
            },
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        DeepBind(model, ConcreteBindingContext.OrganizationalStructuringUnitConfiguration);

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

    private void RootOrganizationlUnityDefineButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationalUnitsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    this.NavigationPushPageAsync(new OrganizationalStructuringUnitConfigurationPage(RootOrganizationlUnitDefine_Callback, new Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel(null)
                    {
                        AvailableOrganizationalUnits = [.. task.Result]
                    }));
                }
            });
        });
    }

    private void OrganizationalUnityEditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationalUnitsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    this.NavigationPushPageAsync(new OrganizationalStructuringUnitConfigurationPage(OrganizationlUnitEdition_Callback, new Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel)
                    {
                        AvailableOrganizationalUnits = [.. task.Result]
                    }));
                }
            });
        });
    }

    private void OrganizationalUnityAddChildButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationalUnitsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    this.NavigationPushPageAsync(new OrganizationalStructuringUnitConfigurationPage(OrganizationalUnitAddChild_Callback, new Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel(null)
                    {
                        AvailableOrganizationalUnits = [.. task.Result],
                        Parent = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel
                    }));
                }
            });
        });
    }

    private void OrganizationalUnityRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este elemento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel;

                var handled = false;

                foreach (var item in target.Parent.IncomingInteropChildren)
                {
                    if (item.Id != target.Id) continue;

                    target.Parent.IncomingInteropChildren.Remove(target.Parent.IncomingInteropChildren.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in target.Parent.EditionInteropChildren)
                    {
                        if (item.Id != target.Id) continue;

                        target.Parent.EditionInteropChildren.Remove(target.Parent.EditionInteropChildren.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    target.Parent.OutgoingInteropChildren.Add(new Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel(target));
                }

                target.Parent.Children.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void RootOrganizationlUnitDefine_Callback(Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel model)
    {
        ConcreteBindingContext.OrganizationalStructuringUnitConfiguration = new Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel(model);
    }

    private void OrganizationlUnitEdition_Callback(Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel model)
    {
        if (model.Parent == null)
        {
            ConcreteBindingContext.OrganizationalStructuringUnitConfiguration.OrganizationalUnit = model.OrganizationalUnit;
            ConcreteBindingContext.OrganizationalStructuringUnitConfiguration.Reference = model.Reference;

            return;
        }

        var handled = false;

        foreach (var item in model.Parent.IncomingInteropChildren)
        {
            if (item.Id != model.Id) continue;

            item.OrganizationalUnit = model.OrganizationalUnit;
            item.Reference = model.Reference;

            break;
        }

        if (!handled)
        {
            foreach (var item in model.Parent.EditionInteropChildren)
            {
                if (item.Id != model.Id) continue;

                item.OrganizationalUnit = model.OrganizationalUnit;
                item.Reference = model.Reference;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            model.Parent.EditionInteropChildren.Add(new Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel(model));
        }

        var target = model.Parent.Children.First(_model => _model.Id == model.Id);

        target.OrganizationalUnit = model.OrganizationalUnit;
        target.Reference = model.Reference;

        hasChangesFlag = true;
    }

    private void OrganizationalUnitAddChild_Callback(Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel model)
    {
        var target = new Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel(model);

        model.Parent.Children.Add(target);

        model.Parent.IncomingInteropChildren.Add(target);

        hasChangesFlag = true;
    }

    private static void DeepBind(Interop.API.Common.Models.Input.OrganizationalStructureInputModel context, Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel model)
    {
        foreach (var _model in model.IncomingInteropChildren)
        {
            context.IncomingStructuringUnits.Add(new Interop.API.Common.Models.Input.OrganizationalStructuringUnitInputModel
            {
                Id = _model.Id,
                OrganizationalUnitId = _model.OrganizationalUnit.Id,
                Reference = _model.Reference,
                ParentId = model.Id
            });
        }

        foreach (var _model in model.EditionInteropChildren)
        {
            context.EditionStructuringUnits.Add(new Interop.API.Common.Models.Input.OrganizationalStructuringUnitInputModel
            {
                Id = _model.Id,
                OrganizationalUnitId = _model.OrganizationalUnit.Id,
                Reference = _model.Reference,
                ParentId = model.Id
            });
        }

        foreach (var _model in model.OutgoingInteropChildren)
        {
            context.OutgoingStructuringUnits.Add(new Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel { Id = _model.Id });
        }

        foreach (var _model in model.Children)
        {
            DeepBind(context, _model);
        }
    }
}