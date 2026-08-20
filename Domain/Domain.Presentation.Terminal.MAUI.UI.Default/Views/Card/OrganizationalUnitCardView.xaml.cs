namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class OrganizationalUnitCardView : Microsoft.Maui.Controls.ContentView
{
	public OrganizationalUnitCardView()
	{
		InitializeComponent();
	}

	public event System.EventHandler<Microsoft.Maui.Controls.TappedEventArgs> ItemTapGestureRecognizerTapped;

    private void TapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs eventArgs)
    {
        ItemTapGestureRecognizerTapped.Invoke(sender, eventArgs);
    }
}