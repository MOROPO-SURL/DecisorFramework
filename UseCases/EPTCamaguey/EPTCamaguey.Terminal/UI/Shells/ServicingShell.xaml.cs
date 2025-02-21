namespace MOROPO.EPTCamaguey.Decisor.Terminal.UI.Shells;

public partial class ServicingShell : Microsoft.Maui.Controls.Shell
{
	public ServicingShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}