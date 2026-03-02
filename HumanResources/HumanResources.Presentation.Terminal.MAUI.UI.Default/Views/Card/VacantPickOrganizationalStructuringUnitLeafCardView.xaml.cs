namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class VacantPickOrganizationalStructuringUnitLeafCardView : Microsoft.Maui.Controls.ContentView
{
	public VacantPickOrganizationalStructuringUnitLeafCardView()
	{
		InitializeComponent();
    }

    public event System.EventHandler<Microsoft.Maui.Controls.TappedEventArgs> ItemTapped;

    private void TapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ItemTapped(sender, e);
    }
}