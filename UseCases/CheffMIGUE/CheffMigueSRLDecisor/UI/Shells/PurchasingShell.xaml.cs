namespace MOROPO.CheffMigueSRL.Decisor.Terminal.UI.Shells;

public partial class PurchasingShell : Microsoft.Maui.Controls.Shell
{
	public PurchasingShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}