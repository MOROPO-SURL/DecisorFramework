namespace MOROPO.EPTCamaguey.Decisor.Terminal.UI.Shells;

public partial class CommercialShell : Microsoft.Maui.Controls.Shell
{
    public CommercialShell()
    {
        InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}