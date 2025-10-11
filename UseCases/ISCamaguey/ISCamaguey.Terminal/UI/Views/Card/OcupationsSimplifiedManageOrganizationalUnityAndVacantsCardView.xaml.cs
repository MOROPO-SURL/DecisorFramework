namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Views.Card;

public partial class OcupationsSimplifiedManageOrganizationalUnityAndVacantsCardView : Microsoft.Maui.Controls.ContentView
{
    public OcupationsSimplifiedManageOrganizationalUnityAndVacantsCardView()
    {
        InitializeComponent();
    }

    public event System.EventHandler CreateOcupationButtonClick;

    public event System.EventHandler RemoveOcupationButtonClick;

    public event System.EventHandler EmployeeDetailButtonClick;

    private void CreateOcupationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        CreateOcupationButtonClick?.Invoke(sender, eventArgs);
    }

    private void RemoveOcupationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        RemoveOcupationButtonClick?.Invoke((object)sender, eventArgs);
    }

    private void EmployeeDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        EmployeeDetailButtonClick?.Invoke(sender, eventArgs);
    }

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
}