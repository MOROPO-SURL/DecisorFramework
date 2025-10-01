namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Shells;

public partial class QualityShell : Microsoft.Maui.Controls.Shell
{
	public QualityShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}