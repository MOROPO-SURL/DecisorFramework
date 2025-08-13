using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.List;

public partial class VehicleLeaseOfferTenderListPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Models.Page.List.VehicleLeaseOfferTenderListPageModel, Detail.VehicleLeaseOfferDetailPage>
{
    public VehicleLeaseOfferTenderListPage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return -1;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOffersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync();
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }

    private void LoadMoreBurron_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnLoadMore(sender, eventArgs);
    }

    private void ItemsCollectionViewLayout_SizeChanged(object sender, System.EventArgs eventArgs)
    {
        OnItemsCollectionViewLayoutResize(sender, eventArgs);
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}