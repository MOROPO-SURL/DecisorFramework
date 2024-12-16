namespace MOROPO.EPTCamaguey.Decisor.Terminal.MAUI.UI.Shells;

public partial class HumanResourcesShell : Microsoft.Maui.Controls.Shell
{
    public HumanResourcesShell()
    {
        InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}
