using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class SimplfiedGovernanceDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.SimplfiedGovernanceDashboardPageModel>
{
    public SimplfiedGovernanceDashboardPage() : base(new Models.Page.SimplfiedGovernanceDashboardPageModel())
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

            var groupsAPIConnectClient = new Framework.Decisor.Governance.Interop.API.Connect.Clients.DecisionMakingGroupsAPIConnectClient(httpClientHelperProvider);
            var meetingsAPIConnectClient = new Framework.Decisor.Governance.Interop.API.Connect.Clients.MeetingsAPIConnectClient(httpClientHelperProvider);
            var agreementsAPIConnectClient = new Framework.Decisor.Governance.Interop.API.Connect.Clients.AgreementsAPIConnectClient(httpClientHelperProvider);

            var groupCount = await groupsAPIConnectClient.CountAsync();
            var meetingCount = await meetingsAPIConnectClient.CountAsync();
            var agreementCount = await agreementsAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.HasAnyGroup = groupCount > 0;
                BindingContextPageModel.HasAnyMeeting = meetingCount > 0;
                BindingContextPageModel.HasAnyAgreement = agreementCount > 0;
                BindingContextPageModel.IsModuleReady = BindingContextPageModel.HasAnyGroup && BindingContextPageModel.HasAnyMeeting && BindingContextPageModel.HasAnyAgreement;

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

    private async void GoGroupsManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.DecisionMakingGroupsManagePage).Name}"));
    }

    private async void GoMeetingsManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.MeetingsManagePage).Name}"));
    }
}