namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages
{
    public partial class MainPage : Microsoft.Maui.Controls.ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, System.EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            Microsoft.Maui.Accessibility.SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
