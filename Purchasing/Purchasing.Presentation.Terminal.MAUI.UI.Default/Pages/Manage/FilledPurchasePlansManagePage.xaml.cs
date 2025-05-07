using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Enumerations;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class FilledPurchasePlansManagePage : Caney.MVVM.Core.Pages.ContentPage
{
    public FilledPurchasePlansManagePage()
    {
        InitializeComponent();

        IsEnabled = false;

        BindingContext = new Models.Page.Manage.PurchasePlansManagePageModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled) return;

        LoadItems();

        IsEnabled = true;
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (((Models.Page.Manage.PurchasePlansManagePageModel)BindingContext).IsBusy) return;

        LoadItems();
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ((Models.Page.Manage.PurchasePlansManagePageModel)BindingContext).PresentedItem = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PurchasePlanDisplayModel;
    }

    private void PresentedItemDismissButton_Clicked(object sender, System.EventArgs e)
    {
        ((Models.Page.Manage.PurchasePlansManagePageModel)BindingContext).PresentedItem = null;
    }

    private void LoadItems()
    {
        var concreteBindingContext = (Models.Page.Manage.PurchasePlansManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        concreteBindingContext.Items.Clear();

        var apiConnectClient = new Interop.API.Connect.Clients.PurchasePlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        apiConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.PurchasePlanFilterModel { Kind = CommonPlanFilterKind.Handled }).ContinueWith(task =>
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