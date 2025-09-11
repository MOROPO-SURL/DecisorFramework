namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class VacantPickOrganizationalUnityCardView : Microsoft.Maui.Controls.ContentView
{
	public VacantPickOrganizationalUnityCardView()
	{
		InitializeComponent();
    }

    public event System.EventHandler<Microsoft.Maui.Controls.TappedEventArgs> ItemTapped;

    private void ItemsCollectionViewLayoutControl_SizeChanged(object sender, System.EventArgs eventArgs)
    {
        var itemsCollectionViewItemsLayout = VacantsCollectionView.ItemsLayout as Microsoft.Maui.Controls.GridItemsLayout;

        var itemsCollectionViewLayout = sender as Microsoft.Maui.Controls.Layout;

        if (itemsCollectionViewLayout.Width < 0 || itemsCollectionViewLayout.Height < 0) return;

        var reazon = itemsCollectionViewLayout.Width / (200 + itemsCollectionViewItemsLayout.HorizontalItemSpacing);

        int columnCount = System.Convert.ToInt32(System.Math.Round(reazon, System.MidpointRounding.ToEven));

        if (columnCount > reazon)
        {
            columnCount--;
        }

        if (columnCount <= 0)
        {
            columnCount = 1;
        }

        itemsCollectionViewItemsLayout.Span = columnCount;
    }

    private void TapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ItemTapped?.Invoke(sender, e);
    }
}