using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class PurchasesManagePage : Caney.MVVM.Core.Pages.ContentPage
{
    public PurchasesManagePage()
    {
        InitializeComponent();

        IsEnabled = false;

        BindingContext = new Models.Page.Manage.PurchasesManagePageModel();
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
        var concreteBindingContext = (Models.Page.Manage.PurchasesManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var zonesAPIConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var employeesAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchaseConfigurationPageModel(null)
                {
                    AvailablePurchasers = await employeesAPIConnectClient.GetAsync(),
                    AvailableZones = await zonesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Configuration.PurchaseConfigurationPage(ConfigurationSuccess_Callback, model));

                    PresentedItemDismissButton_Clicked(sender, e);
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (((Models.Page.Manage.PurchasesManagePageModel)BindingContext).IsBusy) return;

        LoadItems();
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ((Models.Page.Manage.PurchasesManagePageModel)BindingContext).PresentedItem = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PurchaseDisplayModel;
    }

    private void PresentedItemDismissButton_Clicked(object sender, System.EventArgs e)
    {
        ((Models.Page.Manage.PurchasesManagePageModel)BindingContext).PresentedItem = null;
    }

    private void PresentedItemEditButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Manage.PurchasesManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var zonesAPIConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var employeesAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchaseConfigurationPageModel(concreteBindingContext.PresentedItem)
                {
                    AvailablePurchasers = await employeesAPIConnectClient.GetAsync(),
                    AvailableZones = await zonesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Configuration.PurchaseConfigurationPage(ConfigurationSuccess_Callback, model));

                    PresentedItemDismissButton_Clicked(sender, e);
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void PresentedItemRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmar", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var concreteBindingContext = (Models.Page.Manage.PurchasesManagePageModel)BindingContext;

            var apiConnectClient = new Interop.API.Connect.Clients.PurchasesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

            apiConnectClient.ArchiveAsync(concreteBindingContext.PresentedItem.Id).ContinueWith(_task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    if (_task.Exception != null || _task.IsCanceled)
                    {
                        DisplayAlert("Aviso", "Error no esperado!!", "Aceptar");
                    }
                    else
                    {
                        concreteBindingContext.PresentedItem = null;

                        DisplayAlert("Aviso", "Elemento eliminado con �xito.", "Aceptar");

                        LoadItems();
                    }
                });
            });
        });
    }

    private void ConfigurationSuccess_Callback(Interop.API.Common.Models.Display.PurchaseDisplayModel model)
    {
        LoadItems();
    }

    private void LoadItems()
    {
        var concreteBindingContext = (Models.Page.Manage.PurchasesManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        concreteBindingContext.Items.Clear();

        var apiConnectClient = new Interop.API.Connect.Clients.PurchasesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                concreteBindingContext.IsBusy = false;

                if (task.Exception != null || task.IsCanceled)
                {
                    DisplayAlert("Aviso", "Error no esperado!!", "Aceptar");
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