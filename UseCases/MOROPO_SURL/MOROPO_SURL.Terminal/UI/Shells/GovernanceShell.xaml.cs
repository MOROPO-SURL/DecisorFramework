namespace MOROPO.Tool.Decisor.Terminal.UI.Shells;

public partial class GovernanceShell : Microsoft.Maui.Controls.Shell
{
	public GovernanceShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}