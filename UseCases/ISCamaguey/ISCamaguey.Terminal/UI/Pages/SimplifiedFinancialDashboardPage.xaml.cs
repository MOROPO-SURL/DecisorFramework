using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class SimplifiedFinancialDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseFinancialDashboardPageModel>
{
    public SimplifiedFinancialDashboardPage() : base(new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseFinancialDashboardPageModel())
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
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var bankAgenciesAPIConnectClient = new Framework.Decisor.Financial.Interop.API.Connect.Clients.BankAgenciesAPIConnectClient(httpClientHelperProvider);
            var bankBrenchsAPIConnectClient = new Framework.Decisor.Financial.Interop.API.Connect.Clients.BankBranchesAPIConnectClient(httpClientHelperProvider);
            var currenciesAPIConnectClient = new Framework.Decisor.Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(httpClientHelperProvider);

            var bankAgencyCount = await bankAgenciesAPIConnectClient.CountAsync();
            var bankBrenchCount = await bankBrenchsAPIConnectClient.CountAsync();
            var currencyCount = await currenciesAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.HasAnyBankAgency = bankAgencyCount > 0;
                BindingContextPageModel.HasAnyBankBrench = bankBrenchCount > 0;
                BindingContextPageModel.HasAnyCurrency = currencyCount > 0;
                BindingContextPageModel.IsModuleReady = BindingContextPageModel.HasAnyBankAgency && BindingContextPageModel.HasAnyBankBrench && BindingContextPageModel.HasAnyCurrency;

                BindingContextPageModel.IsBusy = false;
            });
        }).ContinueWith(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled) return;

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.IsBusy = false;

                this.PresentToastNotification(Framework.Decisor.Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Error, "No fue posible actualizar la información en este momento.", delay: System.TimeSpan.FromMilliseconds(500));
            });
        });
    }

    private async void GoBankAgenciesManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.BankAgenciesManagePage).Name}"));
    }

    private async void GoBankBrenchsManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.BankBranchesManagePage).Name}"));
    }

    private async void GoCurrenciesManageSiteManagePageButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.CurrenciesManagePage).Name}"));
    }
}