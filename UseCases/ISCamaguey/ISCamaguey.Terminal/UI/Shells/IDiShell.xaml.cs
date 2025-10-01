namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Shells;

public partial class IDiShell : Microsoft.Maui.Controls.Shell
{
	public IDiShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}