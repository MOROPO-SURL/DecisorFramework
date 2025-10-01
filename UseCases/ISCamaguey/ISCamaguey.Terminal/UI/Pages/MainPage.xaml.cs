using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

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

    private void HumanResourcesSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.HumanResourcesShell();
    }

    private void FinancialSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.FinancialShell();
    }

    private void ProductionSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.ProductionShell();
    }

    private void CommecrcialSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.CommercialShell();
    }

    private void ResearchSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.IDiShell();
    }

    private void ServiceSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.ServicingShell();
    }

    private void LabSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.LabShell();
    }

    private void RecomendationSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        //Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.CommercialShell();
    }

    private void QualitySectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Shells.QualityShell();
    }
}
