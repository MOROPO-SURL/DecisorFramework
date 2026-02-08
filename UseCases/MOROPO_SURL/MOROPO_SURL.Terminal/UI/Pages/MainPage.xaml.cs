using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Tool.Decisor.Terminal.UI.Pages;

public partial class MainPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel>
{
    public MainPage() : base(new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel
    {
        OwnerInformation = Providers.SingleRuntimeContextProvider.OWNER_INFORMATION
    })
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var sessionManager = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>();

        BindingContextPageModel.User = sessionManager.CurrentSession?.User;

        if (BindingContextPageModel.User == null)
        {
            this.NavigationPushModalPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.DefaultUserAuthenticationPage());
        }
        else
        {
            var apiConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.ChangeNotificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            apiConnectClient.GetUnreadCountAsync().ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (task.Exception != null || task.IsCanceled || task.Result == 0)
                    {
                        BindingContextPageModel.NotificationCount = null;
                    }
                    else
                    {
                        BindingContextPageModel.NotificationCount = task.Result;
                    }
                });
            });
        }
    }

    private void DomainSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.DomainShell();
    }

    private void LegalSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.LegalShell();
    }

    private void HumanResourcesSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.HumanResourcesShell();
    }

    private void FinancialSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.FinancialShell();
    }

    private void PurchasingSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.PurchasingShell();
    }

    private void InventorySectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.InventoryShell();
    }

    private void ProductionSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.ProductionShell();
    }

    private void CommecrcialSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.CommercialShell();
    }

    private void SalesSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.SalesShell();
    }

    private void LeasingSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.LeasingShell();
    }

    private void GovernanceSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.GovernanceShell();
    }

    private void SupervisionSectionCardFrameTapGEstureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        //try
        //{
        //    Microsoft.Maui.Controls.Application.Current.MainPage = new Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.BankAgenciesManagePage();
        //}
        //catch (System.Exception exception)
        //{
        //    DisplayAlert("Aviso", string.Format("Page build failure!! {0}", exception.Message), "Aceptar");

        //    return;
        //}
    }

    private void NotificationsLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.List.ChangeNotificationsListPage()));
    }
}