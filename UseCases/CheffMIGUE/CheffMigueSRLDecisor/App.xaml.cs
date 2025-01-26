namespace MOROPO.CheffMigueSRL.Decisor.Terminal;

public partial class App : Microsoft.Maui.Controls.Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new UI.Pages.MainPage();
	}

    protected override void OnStart()
    {
        base.OnStart();

		Windows[0].Title = "CheffMIGUE S.R.L. Decisor";
    }
}