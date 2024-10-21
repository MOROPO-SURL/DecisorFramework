using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.UseCase.Terminal.MAUI.UI.Pages;

public partial class MainPage : Caney.MVVM.Core.Pages.BindingContextedContentPage<Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel>
{
	public MainPage() : base(new Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel())
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var sessionManager = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>();

        BindingContextPageModel.User = sessionManager.CurrentSession?.User;

        if (BindingContextPageModel.User == null)
        {
            this.NavigationPushModalPageAsync(new Core.Presentation.Terminal.MAUI.UI.Page.DefaultUserAuthenticationPage());
        }
    }
}
