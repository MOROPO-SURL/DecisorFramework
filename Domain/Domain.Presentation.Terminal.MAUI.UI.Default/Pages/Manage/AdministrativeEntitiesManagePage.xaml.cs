using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class AdministrativeEntitiesManagePage : Caney.MVVM.Core.Pages.ContentPage
{
    public AdministrativeEntitiesManagePage()
    {
        InitializeComponent();

        IsEnabled = false;

        BindingContext = new Models.Page.Manage.AdministrativeEntitiesManagePageModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled) return;

        LoadItems();

        IsEnabled = true;
    }

    private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Manage.AdministrativeEntitiesManagePageModel)BindingContext;

        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.StructureCreatorPermission)))
        {
            DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar elementos. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            concreteBindingContext.IsBusy = false;

            return;
        }

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                var administrativeEntitiesAPIConnectClient = new Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(httpClientHelperProvider);
                var organizationlStructuresAPIConnectClient = new Interop.API.Connect.Clients.OrganizationalStructuresAPIConnectClient(httpClientHelperProvider);
                var kindAPIConnectClient = new Interop.API.Connect.Clients.AdministrativeEntityKindsAPIConnectClient(httpClientHelperProvider);

                var model = new Models.Page.Configuration.AdministrativeEntityConfigurationPageModel(null)
                {
                    AvailableParents = await administrativeEntitiesAPIConnectClient.GetAsync(),
                    AvailableOrganizationalStructures = await organizationlStructuresAPIConnectClient.GetAsync(),
                    AvailableKinds = await kindAPIConnectClient.GetEnabledAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Configuration.AdministrativeEntityConfigurationPage(ConfigurationSuccess_Callback, model, new Validators.AdministrativeEntityConfigurationValidator()));
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

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (((Models.Page.Manage.AdministrativeEntitiesManagePageModel)BindingContext).IsBusy) return;

        LoadItems();
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var concreteBindingContext = (Models.Page.Manage.AdministrativeEntitiesManagePageModel)BindingContext;

        if (concreteBindingContext.IsBusy) return;

        concreteBindingContext.IsBusy = true;

        var structureAPIConnectClient = new Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        structureAPIConnectClient.GetAsync(((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Interop.API.Common.Models.Display.AdministrativeEntityTreeDisplayModel).Id).ContinueWith(task =>
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
                    this.NavigationPushModalPageAsync(new Detail.AdministrativeEntityDetailPage(task.Result, DetailActionDelegationRequest_Callback));
                }
            });
        });
    }
    private void DetailActionDelegationRequest_Callback(Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel target, int? discriminator)
    {
        var concreteBindingContext = (Models.Page.Manage.AdministrativeEntitiesManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        if (discriminator == null)
        {
            var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

            if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.StructureEditorPermission)))
            {
                DisplayAlert("Aviso", "Su usuario no cuenta con permisos para modificar elementos registrados. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                concreteBindingContext.IsBusy = false;

                return;
            }

            System.Threading.Tasks.Task.Run((System.Func<System.Threading.Tasks.Task>)(async () =>
            {
                var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                var administrativeEntitiesAPIConnectClient = new Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(httpClientHelperProvider);
                var organizationlStructuresAPIConnectClient = new Interop.API.Connect.Clients.OrganizationalStructuresAPIConnectClient(httpClientHelperProvider);
                var kindAPIConnectClient = new Interop.API.Connect.Clients.AdministrativeEntityKindsAPIConnectClient(httpClientHelperProvider);

                var parents = new System.Collections.Generic.List<Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel>(await administrativeEntitiesAPIConnectClient.GetAsync());

                parents.RemoveAll(model => IsSelectable(target, model));

                var model = new Models.Page.Configuration.AdministrativeEntityConfigurationPageModel(await administrativeEntitiesAPIConnectClient.GetAsync(target.Id))
                {
                    AvailableParents = [.. parents],
                    AvailableOrganizationalStructures = await organizationlStructuresAPIConnectClient.GetAsync(),
                    AvailableKinds = await kindAPIConnectClient.GetEnabledAsync()
                };

                Dispatcher.Dispatch((System.Action)(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync((Microsoft.Maui.Controls.Page)new Configuration.AdministrativeEntityConfigurationPage(ConfigurationSuccess_Callback, model, new Validators.AdministrativeEntityConfigurationValidator()));
                }));
            }));
        }
        else if (discriminator == 0)
        {
            DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                var concreteBindingContext = (Models.Page.Manage.AdministrativeEntitiesManagePageModel)BindingContext;

                var apiConnectClient = new Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.ArchiveAsync(target.Id).ContinueWith(_task =>
                {
                    Dispatcher.Dispatch(() =>
                    {
                        concreteBindingContext.IsBusy = false;

                        if (_task.Exception != null || _task.IsCanceled)
                        {
                            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                        }
                        else
                        {
                            DisplayAlert("Aviso", "Elemento eliminado con éxito.", "Aceptar");

                            LoadItems();
                        }
                    });
                });
            });
        }
    }

    private void ConfigurationSuccess_Callback(Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel model)
    {
        this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.", delay: System.TimeSpan.FromMilliseconds(500)); 
        
        LoadItems();
    }

    private void LoadItems()
    {
        var concreteBindingContext = (Models.Page.Manage.AdministrativeEntitiesManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        concreteBindingContext.Items.Clear();

        var apiConnectClient = new Interop.API.Connect.Clients.TreeAdministrativeEntitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
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
                    foreach (var model in task.Result)
                    {
                        concreteBindingContext.Items.Add(model);
                    }
                }
            });
        });
    }

    private bool IsSelectable(Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel target, Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel model)
    {
        if (model.Id == target.Id) return true;

        if (model.Parent == null) return false;

        return IsSelectable(target, model.Parent);
    }
}