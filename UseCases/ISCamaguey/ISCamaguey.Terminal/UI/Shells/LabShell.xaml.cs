namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Shells;

public partial class LabShell : Microsoft.Maui.Controls.Shell
{
	public LabShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}