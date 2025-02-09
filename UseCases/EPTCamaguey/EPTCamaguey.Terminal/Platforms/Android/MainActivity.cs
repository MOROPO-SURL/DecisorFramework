using Android.App;
using Android.Content.PM;

namespace MOROPO.EPTCamaguey.Decisor.Terminal.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : Microsoft.Maui.MauiAppCompatActivity
    {
    }
}
