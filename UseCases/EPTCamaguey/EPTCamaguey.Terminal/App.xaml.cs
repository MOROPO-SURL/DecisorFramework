namespace MOROPO.EPTCamaguey.Decisor.Terminal
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new UI.Pages.MainPage();
        }

        protected override void OnStart()
        {
            base.OnStart();

            FFImageLoading.ImageService.Instance.Configuration.DiskCacheDuration = System.TimeSpan.MaxValue;

            Windows[0].Title = "EPT Camagüey Decisor™";
        }
    }
}
