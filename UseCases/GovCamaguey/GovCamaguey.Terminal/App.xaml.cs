using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new UI.Shells.AppShell();
    }

    protected override void OnStart()
    {
        base.OnStart();

        Windows[0].Title = $"Gobierno de Camagüey - Decisor™ v{Microsoft.Maui.ApplicationModel.AppInfo.Current.VersionString}";
    }
}