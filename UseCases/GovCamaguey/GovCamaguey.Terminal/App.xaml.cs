namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal
{
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

            Windows[0].Title = $"{Providers.SingleRuntimeContextProvider.OWNER_INFORMATION.Name} - Decisor";
        }
    }
}
