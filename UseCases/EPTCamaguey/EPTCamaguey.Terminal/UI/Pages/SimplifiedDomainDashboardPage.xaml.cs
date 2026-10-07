using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.EPTCamaguey.Decisor.Terminal.UI.Pages;

public partial class SimplifiedDomainDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseDomainDashboardPageModel>
{
	public SimplifiedDomainDashboardPage() : base(new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.BaseDomainDashboardPageModel())
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

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var organizationalUnitsAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.OrganizationalUnitsAPIConnectClient(httpClientHelperProvider);
        var organizationalStructuresAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.OrganizationalStructuresAPIConnectClient(httpClientHelperProvider);
        var administrativeEntityKindsAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.AdministrativeEntityKindsAPIConnectClient(httpClientHelperProvider);
        var administrativeEntitiesAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(httpClientHelperProvider);

        var organizationalUnitCountTask = organizationalUnitsAPIConnectClient.CountAsync();
        var organizationalStructureCountTask = organizationalStructuresAPIConnectClient.CountAsync();
        var administrativeEntityKindCountTask = administrativeEntityKindsAPIConnectClient.CountAsync();
        var administrativeEntityCountTask = administrativeEntitiesAPIConnectClient.CountAsync();

        System.Threading.Tasks.Task.WhenAll(organizationalUnitCountTask, organizationalStructureCountTask, administrativeEntityKindCountTask, administrativeEntityCountTask).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.IsBusy = false;

                if (!task.IsCompletedSuccessfully)
                {
                    this.PresentToastNotification(Framework.Decisor.Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Error, "No fue posible actualizar la información en este momento.", delay: System.TimeSpan.FromMilliseconds(500));
                    
                    return;
                }

                BindingContextPageModel.HasAnyAdministrativeEntity = administrativeEntityCountTask.Result > 0;
                BindingContextPageModel.HasAnyOrganiuzationalStructure = organizationalStructureCountTask.Result > 0;
                BindingContextPageModel.HasAnyAdministrativeEntityKind = administrativeEntityKindCountTask.Result > 0;
                BindingContextPageModel.HasAnyOrganizationalUnit = organizationalUnitCountTask.Result > 0;
                BindingContextPageModel.IsModuleReady = 
                    BindingContextPageModel.HasAnyAdministrativeEntity && 
                    BindingContextPageModel.HasAnyOrganiuzationalStructure && 
                    BindingContextPageModel.HasAnyAdministrativeEntityKind && 
                    BindingContextPageModel.HasAnyOrganizationalUnit;
            });
        }).ContinueWith(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled) return;

            Dispatcher.Dispatch(() =>
            {
            });
        });
    }

    private async void GoOrganizationalUnitsManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.OrganizationalUnitsManagePage).Name}"));
    }

    private async void GoOrganizationalStructuresManageSiteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.OrganizationalStructuresManagePage).Name}"));
    }

    private async void GoAdministrativeEntityKindsAdminSiteManagePageButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/domain/administrativeentitykinds");
    }

    private async void GoAdministrativeEntitiesManageSiteManagePageButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync(new Microsoft.Maui.Controls.ShellNavigationState($"///{typeof(Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.AdministrativeEntitiesManagePage).Name}"));
    }
}