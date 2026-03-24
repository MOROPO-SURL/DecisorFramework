using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.UI.Default.Pages;

public partial class CommercialDashboardPage : Caney.MVVM.Core.Pages.BindingContextedContentPage<Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseCommercialDashboardPageModel>
{
    public CommercialDashboardPage() : base(new Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseCommercialDashboardPageModel())
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Refresh();
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        Refresh();
    }

    public void Refresh()
    {
        BindingContextPageModel.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var legalBusinessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.LegalBusinessKindsAPIConnectClient(httpClientHelperProvider);
            var naturalBusinessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(httpClientHelperProvider);
            var paymentTermsAPIConnectClient = new Commercial.Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);

            var legalBusinessKindCount = await legalBusinessKindsAPIConnectClient.CountAsync();
            var naturalBusinessKindCount = await naturalBusinessKindsAPIConnectClient.CountAsync();
            var paymentTermCount = await paymentTermsAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.HasAnyLegalBusinessKind = legalBusinessKindCount > 0;
                BindingContextPageModel.HasAnyNaturalBusinessKind = naturalBusinessKindCount > 0;
                BindingContextPageModel.HasAnyPaymentTerm = paymentTermCount > 0;
                BindingContextPageModel.IsModuleReady = 
                    BindingContextPageModel.HasAnyLegalBusinessKind && 
                    BindingContextPageModel.HasAnyNaturalBusinessKind && 
                    BindingContextPageModel.HasAnyPaymentTerm;

                BindingContextPageModel.IsBusy = false;
            });
        }).ContinueWith(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled) return;

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.IsBusy = false;

                this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Error, "No fue posible actualizar la información en este momento.", delay: System.TimeSpan.FromMilliseconds(500));
            });
        });
    }

    private async void GoLegalBusinessKindsAdminSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/domain/legalbusinesskinds");
    }

    private async void GoNaturalBusinessKindsAdminSiteManagePageButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/domain/naturalbusinesskinds");
    }

    private async void GoPaymentTermsAdminSiteManagePageButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/commercial/paymentterms");
    }
}