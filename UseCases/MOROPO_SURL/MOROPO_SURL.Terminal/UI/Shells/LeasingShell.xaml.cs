namespace MOROPO.Tool.Decisor.Terminal.UI.Shells;

public partial class LeasingShell : Microsoft.Maui.Controls.Shell
{
    public LeasingShell()
    {
        InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}