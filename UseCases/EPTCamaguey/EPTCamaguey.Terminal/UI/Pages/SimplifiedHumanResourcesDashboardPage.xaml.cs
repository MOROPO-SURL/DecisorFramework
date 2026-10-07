using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.EPTCamaguey.Decisor.Terminal.UI.Pages;

public partial class SimplifiedHumanResourcesDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseHumanResourcesDashboardPageModel>
{
    public SimplifiedHumanResourcesDashboardPage() : base(new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseHumanResourcesDashboardPageModel())
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

            var workPositionKindsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.WorkPositionKindsAPIConnectClient(httpClientHelperProvider);
            var workPositionsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(httpClientHelperProvider);
            var salaryStandardsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.SalaryStandardsAPIConnectClient(httpClientHelperProvider);
            var workforcesAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.WorkforcesAPIConnectClient(httpClientHelperProvider);
            var staffsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.StaffsAPIConnectClient(httpClientHelperProvider);
            var ocupationsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.OcupationsAPIConnectClient(httpClientHelperProvider);

            var workPositionKindCount = await workPositionKindsAPIConnectClient.CountAsync();
            var workPositionCount = await workPositionsAPIConnectClient.CountAsync();
            var salaryStandardCount = await salaryStandardsAPIConnectClient.CountAsync();
            var workforceCount = await workforcesAPIConnectClient.CountAsync();
            var staffCount = await staffsAPIConnectClient.CountAsync();
            var ocupationCount = await ocupationsAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.HasAnyWorkPositionKind = workPositionKindCount > 0;
                BindingContextPageModel.HasAnyWorkPosition = workPositionCount > 0;
                BindingContextPageModel.HasAnySalaryStandard = salaryStandardCount > 0;
                BindingContextPageModel.HasAnyWorkforce = workforceCount > 0;
                BindingContextPageModel.HasAnyStaff = staffCount > 0;
                BindingContextPageModel.HasAnyOcupation = ocupationCount > 0;
                BindingContextPageModel.IsModuleReady = 
                    BindingContextPageModel.HasAnyWorkPositionKind && 
                    BindingContextPageModel.HasAnyWorkPosition && 
                    BindingContextPageModel.HasAnySalaryStandard && 
                    BindingContextPageModel.HasAnyWorkforce &&
                    BindingContextPageModel.HasAnyStaff &&
                    BindingContextPageModel.HasAnyOcupation;

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

    private async void GoWorkPositionKindsAdminSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/hhrr/workpositionkinds");
    }

    private async void GoWorkPositionsManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.WorkPositionsManagePage).Name}"));
    }

    private async void GoSalaryStandardsManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.SalaryStandardsManagePage).Name}"));
    }

    private async void GoWorkforcesManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.WorkforcesManagePage).Name}"));
    }

    private async void GoStaffsManageSiteManagePageButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.StaffsManagePage).Name}"));
    }

    private async void GoOcupationsManageSiteManagePageButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Manage.OcupationsSimplifiedManagePage).Name}"));
    }
}