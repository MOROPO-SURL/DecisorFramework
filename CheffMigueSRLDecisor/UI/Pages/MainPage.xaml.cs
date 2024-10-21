using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.CheffMigueSRL.Decisor.Terminal.UI.Pages;

public partial class MainPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel>
{
	public MainPage() : base(new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel())
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
            this.NavigationPushModalPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Page.DefaultUserAuthenticationPage());
        }
    }

    private void PurchasingSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        //this.NavigationPushModalPageAsync(new PurchasingPage());
    }

    private void InventorySectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        //this.NavigationPushModalPageAsync(new LogisticsPage());
    }

    private void ProductionSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        //this.NavigationPushModalPageAsync(new ProductionPage());
    }

    private void HumanResourcesSectionCardFrameTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.NavigationPushModalPageAsync(new HumanResourcesPage());
    }
}
