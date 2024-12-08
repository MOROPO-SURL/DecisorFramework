using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class BankDebitCardsManagePage : Caney.MVVM.Core.Pages.ContentPage
{
    public BankDebitCardsManagePage()
    {
        InitializeComponent();

        IsEnabled = false;

        BindingContext = new Models.Page.Manage.BankDebitCardsManagePageModel();
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
        this.NavigationPushPageAsync(new Configuration.BankDebitCardConfigurationPage(ConfigurationSuccess_Callback, new Models.Page.Configuration.BankDebitCardConfigurationPageModel(null)));
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (((Models.Page.Manage.BankDebitCardsManagePageModel)BindingContext).IsBusy) return;

        LoadItems();
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ((Models.Page.Manage.BankDebitCardsManagePageModel)BindingContext).PresentedItem = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.BankDebitCardDisplayModel;
    }

    private void PresentedItemDismissButton_Clicked(object sender, System.EventArgs e)
    {
        ((Models.Page.Manage.BankDebitCardsManagePageModel)BindingContext).PresentedItem = null;
    }

    private void PresentedItemEditButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Manage.BankDebitCardsManagePageModel)BindingContext;

        this.NavigationPushPageAsync(new Configuration.BankDebitCardConfigurationPage(ConfigurationSuccess_Callback, new Models.Page.Configuration.BankDebitCardConfigurationPageModel(concreteBindingContext.PresentedItem)));

        PresentedItemDismissButton_Clicked(sender, e);
    }

    private void PresentedItemRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var concreteBindingContext = (Models.Page.Manage.BankDebitCardsManagePageModel)BindingContext;

            var apiConnectClient = new Interop.API.Connect.Clients.BankDebitCardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

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

    private void ConfigurationSuccess_Callback(Interop.API.Common.Models.Display.BankDebitCardDisplayModel model)
    {
        LoadItems();
    }

    private void LoadItems()
    {
        var concreteBindingContext = (Models.Page.Manage.BankDebitCardsManagePageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        concreteBindingContext.Items.Clear();

        var apiConnectClient = new Interop.API.Connect.Clients.BankDebitCardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

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