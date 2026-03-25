using Microsoft.Extensions.DependencyInjection;
using MOROPO.CITMACamaguey.Decisor.Terminal.Providers;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.CITMACamaguey.Decisor.Terminal.UI.Pages;

public partial class MainPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel>
{
    public MainPage() : base(new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel
    {
        OwnerInformation = SingleRuntimeContextProvider.OWNER_INFORMATION
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
    private void LogOutButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var sessionManager = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>();

        if (sessionManager.CurrentSession?.User == null) return;

        DisplayAlert("Confirmación", "Está seguro que desea terminar su sesión?", "Confirmar", "Cancelar").ContinueWith(async task =>
        {
            if (!task.Result) return;

            await sessionManager.SignOutAsync();

            Dispatcher.Dispatch(() => this.NavigationPushModalPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.DefaultUserAuthenticationPage()));
        });
    }

    private async void GoUserProfilePageButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}security/account");
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

    private void GovernanceSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.GovernanceShell();
    }

    private void NotificationsLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.List.ChangeNotificationsListPage()));
    }
}
