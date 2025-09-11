using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

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
                var httpClientProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

                var zonesAPIConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(httpClientProvider);
                var costCentersAPIConnectClient = new Financial.Interop.API.Connect.Clients.CostCentersAPIConnectClient(httpClientProvider);
                var employeesAPIConnectClient = new Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(httpClientProvider);

                var model = new Models.Page.Configuration.PurchaseConfigurationPageModel(null)
                {
                    AvailablePurchasers = await employeesAPIConnectClient.GetAsync(),
                    AvailableZones = await zonesAPIConnectClient.GetAsync(),
                    AvailableCostCenters = await costCentersAPIConnectClient.GetAsync()
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
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
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
                var httpClientProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

                var zonesAPIConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(httpClientProvider);
                var costCentersAPIConnectClient = new Financial.Interop.API.Connect.Clients.CostCentersAPIConnectClient(httpClientProvider);
                var employeesAPIConnectClient = new Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(httpClientProvider);

                var model = new Models.Page.Configuration.PurchaseConfigurationPageModel(concreteBindingContext.PresentedItem)
                {
                    AvailablePurchasers = await employeesAPIConnectClient.GetAsync(),
                    AvailableZones = await zonesAPIConnectClient.GetAsync(),
                    AvailableCostCenters = await costCentersAPIConnectClient.GetAsync()
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
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void PresentedItemRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
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
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                    }
                    else
                    {
                        concreteBindingContext.PresentedItem = null;

                        DisplayAlert("Aviso", "Elemento eliminado con éxito.", "Aceptar");

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
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    // TODO Replace by ordering at server with GuamaFramework update!!
                    var orderedResult = task.Result.OrderByDescending(model => model.At).ToArray();

                    foreach (var model in orderedResult)
                    {
                        concreteBindingContext.Items.Add(model);
                    }
                }
            });
        });
    }
}