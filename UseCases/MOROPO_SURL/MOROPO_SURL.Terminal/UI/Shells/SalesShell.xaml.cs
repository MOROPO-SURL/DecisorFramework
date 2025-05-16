namespace MOROPO.Tool.Decisor.Terminal.UI.Shells;

public partial class SalesShell : Microsoft.Maui.Controls.Shell
{
	public SalesShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}