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
}
