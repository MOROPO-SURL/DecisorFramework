using System.Runtime.CompilerServices;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class PropertyLeaseOfferDefaultCardView : Microsoft.Maui.Controls.ContentView
{
	public PropertyLeaseOfferDefaultCardView()
	{
		InitializeComponent();
	}

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
    }
}