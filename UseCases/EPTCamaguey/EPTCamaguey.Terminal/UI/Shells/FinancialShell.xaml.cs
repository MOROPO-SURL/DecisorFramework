namespace MOROPO.EPTCamaguey.Decisor.Terminal.UI.Shells;

public partial class FinancialShell : Microsoft.Maui.Controls.Shell
{
    public FinancialShell()
    {
        InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}
