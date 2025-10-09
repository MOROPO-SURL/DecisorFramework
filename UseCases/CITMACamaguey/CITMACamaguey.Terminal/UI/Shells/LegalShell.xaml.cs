namespace MOROPO.CITMACamaguey.Decisor.Terminal.UI.Shells;

public partial class LegalShell : Microsoft.Maui.Controls.Shell
{
	public LegalShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}