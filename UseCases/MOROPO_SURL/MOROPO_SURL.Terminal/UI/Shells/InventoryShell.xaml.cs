namespace MOROPO.Tool.Decisor.Terminal.UI.Shells;

public partial class InventoryShell : Microsoft.Maui.Controls.Shell
{
    public InventoryShell()
    {
        InitializeComponent();
    }

    private void BackHomeButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new Pages.MainPage();
    }
}