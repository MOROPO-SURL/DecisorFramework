namespace MOROPO.CheffMIGUE.Decisor.Terminal.UI.Shells;

public partial class DomainShell : Microsoft.Maui.Controls.Shell
{
	public DomainShell()
	{
		InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}