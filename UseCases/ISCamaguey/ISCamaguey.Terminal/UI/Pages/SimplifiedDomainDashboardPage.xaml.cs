using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

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

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var organizationalUnitsAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.OrganizationalUnitsAPIConnectClient(httpClientHelperProvider);
            var organizationalStructuresAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.OrganizationalStructuresAPIConnectClient(httpClientHelperProvider);
            var administrativeEntityKindsAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.AdministrativeEntityKindsAPIConnectClient(httpClientHelperProvider);
            var administrativeEntitiesAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(httpClientHelperProvider);

            var organizationalUnitCount = await organizationalUnitsAPIConnectClient.CountAsync();
            var organizationalStructureCount = await organizationalStructuresAPIConnectClient.CountAsync();
            var administrativeEntityKindCount = await administrativeEntityKindsAPIConnectClient.CountAsync();
            var administrativeEntityCount = await administrativeEntitiesAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.HasAnyAdministrativeEntity = administrativeEntityCount > 0;
                BindingContextPageModel.HasAnyOrganiuzationalStructure = organizationalStructureCount > 0;
                BindingContextPageModel.HasAnyAdministrativeEntityKind = administrativeEntityKindCount > 0;
                BindingContextPageModel.HasAnyOrganizationalUnit = organizationalUnitCount > 0;
                BindingContextPageModel.IsModuleReady = BindingContextPageModel.HasAnyAdministrativeEntity && BindingContextPageModel.HasAnyOrganiuzationalStructure && BindingContextPageModel.HasAnyAdministrativeEntityKind && BindingContextPageModel.HasAnyOrganizationalUnit;

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