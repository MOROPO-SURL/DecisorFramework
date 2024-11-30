using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class ToApproveProductionPlansManagePage : Caney.MVVM.Core.Pages.ContentPage
{
    public ToApproveProductionPlansManagePage()
    {
        InitializeComponent();

        IsEnabled = false;

        BindingContext = new Models.Page.Manage.ProductionPlansManagePageModel();
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
        var concreteBindingContext = (Models.Page.Manage.ProductionPlansManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var employeesAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var employees = await employeesAPIConnectClient.GetAsync();

                var model = new Models.Page.Configuration.ProductionPlanConfigurationPageModel(null)
                {
                    AvailablePlanners = employees,
                    AvailableResponsibles = employees,
                    AvailableDecisors = employees
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Configuration.ProductionPlanConfigurationPage(ConfigurationSuccess_Callback, model));

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
        if (((Models.Page.Manage.ProductionPlansManagePageModel)BindingContext).IsBusy) return;

        LoadItems();
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ((Models.Page.Manage.ProductionPlansManagePageModel)BindingContext).PresentedItem = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProductionPlanDisplayModel;
    }

    private void PresentedItemDismissButton_Clicked(object sender, System.EventArgs e)
    {
        ((Models.Page.Manage.ProductionPlansManagePageModel)BindingContext).PresentedItem = null;
    }

    private void PresentedItemApproveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea aprobar este elemento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var concreteBindingContext = (Models.Page.Manage.ProductionPlansManagePageModel)BindingContext;

            var apiConnectClient = new Interop.API.Connect.Clients.ProductionPlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

            apiConnectClient.ApproveAsync(concreteBindingContext.PresentedItem.Id).ContinueWith(_task =>
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

                        DisplayAlert("Aviso", "Elemento aprobado con éxito.", "Aceptar");

                        LoadItems();
                    }
                });
            });
        });
    }

    private void PresentedItemEditButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Manage.ProductionPlansManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var employeesAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var employees = await employeesAPIConnectClient.GetAsync();

                var model = new Models.Page.Configuration.ProductionPlanConfigurationPageModel(concreteBindingContext.PresentedItem)
                {
                    AvailablePlanners = employees,
                    AvailableResponsibles = employees,
                    AvailableDecisors = employees
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Configuration.ProductionPlanConfigurationPage(ConfigurationSuccess_Callback, model));

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
        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var concreteBindingContext = (Models.Page.Manage.ProductionPlansManagePageModel)BindingContext;

            var apiConnectClient = new Interop.API.Connect.Clients.ProductionPlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

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

                        DisplayAlert("Aviso", "Elemento eliminado con éxito.", "Aceptar");

                        LoadItems();
                    }
                });
            });
        });
    }

    private void ConfigurationSuccess_Callback(Interop.API.Common.Models.Display.ProductionPlanDisplayModel model)
    {
        LoadItems();
    }

    private void LoadItems()
    {
        var concreteBindingContext = (Models.Page.Manage.ProductionPlansManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        concreteBindingContext.Items.Clear();

        var apiConnectClient = new Interop.API.Connect.Clients.ProductionPlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        apiConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.ProductionPlanFilterModel { Kind = Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.ToApprove }).ContinueWith(task =>
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