namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class AdministrativeEntityTreeCardView : Microsoft.Maui.Controls.ContentView
{
	public AdministrativeEntityTreeCardView()
	{
		InitializeComponent();
    }

    public event System.EventHandler<Microsoft.Maui.Controls.TappedEventArgs> ItemTapGestureRecognizerTapped;

    private void TapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ItemTapGestureRecognizerTapped.Invoke(sender, e);
    }
}