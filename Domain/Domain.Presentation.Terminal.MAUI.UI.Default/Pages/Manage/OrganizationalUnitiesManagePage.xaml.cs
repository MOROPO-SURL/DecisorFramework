using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class OrganizationalUnitiesManagePage : Caney.MVVM.Core.Pages.ContentPage
{
    public OrganizationalUnitiesManagePage()
    {
        InitializeComponent();

        IsEnabled = false;

        BindingContext = new Models.Page.Manage.OrganizationalUnitiesManagePageModel();
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
        var concreteBindingContext = (Models.Page.Manage.OrganizationalUnitiesManagePageModel)BindingContext;

        if (concreteBindingContext.IsBusy) return;

        var apiConnectClient = new Interop.API.Connect.Clients.ParentalOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        concreteBindingContext.IsBusy = true;

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                concreteBindingContext.IsBusy = false;

                if (task.Exception != null || task.IsCanceled)
                {
                    Dispatcher.Dispatch(() =>
                    {
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                    });
                }
                else
                {
                    var model = new Models.Page.Configuration.OrganizationalUnityConfigurationPageModel(null)
                    {
                        AvailableParents = task.Result
                    };

                    this.NavigationPushPageAsync(new Configuration.OrganizationalUnityConfigurationPage(ConfigurationSuccess_Callback, model));
                }
            });
        });
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (((Models.Page.Manage.OrganizationalUnitiesManagePageModel)BindingContext).IsBusy) return;

        LoadItems();
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var concreteBindingContext = (Models.Page.Manage.OrganizationalUnitiesManagePageModel)BindingContext;

        if (concreteBindingContext.IsBusy) return;

        var apiConnectClient = new Interop.API.Connect.Clients.ParentalOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        concreteBindingContext.IsBusy = true;

        apiConnectClient.GetAsync(((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel).Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                this.NavigationPushModalPageAsync(new Detail.OrganizationalUnityDetailPage(task.Result, DetailActionDelegationRequest_Callback));

                concreteBindingContext.IsBusy = false;
            });
        });
    }

    private void DetailActionDelegationRequest_Callback(Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel target, int? discriminator)
    {
        var concreteBindingContext = (Models.Page.Manage.OrganizationalUnitiesManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        if (discriminator == null)
        {
            var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

            if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.UnitMeasurementEditorPermission)))
            {
                DisplayAlert("Aviso", "Su usuario no cuenta con permisos para modificar elementos registrados. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                concreteBindingContext.IsBusy = false;

                return;
            }

            System.Threading.Tasks.Task.Run(async () =>
            {
                var apiConnectClient = new Interop.API.Connect.Clients.ParentalOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.OrganizationalUnityConfigurationPageModel(target)
                {
                    AvailableParents = await apiConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Configuration.OrganizationalUnityConfigurationPage(ConfigurationSuccess_Callback, model));
                });
            });
        }
        else if (discriminator == 0)
        {
            DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                var concreteBindingContext = (Models.Page.Manage.OrganizationalUnitiesManagePageModel)BindingContext;

                var apiConnectClient = new Interop.API.Connect.Clients.ParentalOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
                            this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Elemento eliminado con éxito.");

                            LoadItems();
                        }
                    });
                });
            });
        }
    }

    private void ConfigurationSuccess_Callback(Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel model)
    {
        this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.", delay: System.TimeSpan.FromMilliseconds(500));

        LoadItems();
    }

    private void LoadItems()
    {
        var concreteBindingContext = (Models.Page.Manage.OrganizationalUnitiesManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        concreteBindingContext.Items.Clear();

        var apiConnectClient = new Interop.API.Connect.Clients.TreeOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
}