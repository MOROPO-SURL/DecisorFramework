using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.UI.Default.Pages;

public partial class GovernanceDashboardPage : Caney.MVVM.Core.Pages.BindingContextedContentPage<Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseGovernanceDashboardPageModel>
{
    public GovernanceDashboardPage() : base(new Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseGovernanceDashboardPageModel())
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

            var groupsAPIConnectClient = new Governance.Interop.API.Connect.Clients.DecisionMakingGroupsAPIConnectClient(httpClientHelperProvider);
            var meetingsAPIConnectClient = new Governance.Interop.API.Connect.Clients.MeetingsAPIConnectClient(httpClientHelperProvider);
            var agreementsAPIConnectClient = new Governance.Interop.API.Connect.Clients.AgreementsAPIConnectClient(httpClientHelperProvider);

            var groupCount = await groupsAPIConnectClient.CountAsync();
            var meetingCount = await meetingsAPIConnectClient.CountAsync();
            var agreementCount = await agreementsAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.HasAnyGroup = groupCount > 0;
                BindingContextPageModel.HasAnyMeeting = meetingCount > 0;
                BindingContextPageModel.HasAnyAgreement = agreementCount > 0;
                BindingContextPageModel.IsModuleReady = 
                    BindingContextPageModel.HasAnyGroup && 
                    BindingContextPageModel.HasAnyMeeting && 
                    BindingContextPageModel.HasAnyAgreement;

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

    private async void GoGroupsManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.DecisionMakingGroupsManagePage).Name}"));
    }

    private async void GoMeetingsManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.MeetingsManagePage).Name}"));
    }
}