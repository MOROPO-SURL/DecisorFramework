namespace MOROPO.Framework.Decisor.UseCase.Terminal.MAUI;

public partial class App : Microsoft.Maui.Controls.Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new UI.Pages.MainPage();
	}
}

