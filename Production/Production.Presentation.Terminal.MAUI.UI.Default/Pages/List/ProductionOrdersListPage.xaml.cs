using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.List;

public partial class ProductionOrdersListPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Models.Page.List.ProductionOrdersListPageModel>
{
    public ProductionOrdersListPage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double ItemViewRequestWidth => Constants.CardViewHeightConstants.PRODUCTION_ORDER_DEFAULT_CARD_VIEW_WIDTH;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewHeightConstants.PRODUCTION_ORDER_DEFAULT_CARD_VIEW_HEIGHT;

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.ProductionOrderDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.FilterPaginateAsync(new Interop.API.Common.Models.Filter.ProductionOrderFilterModel {HasProduction = true, Param = ConcreteBindingContext.SearchParameter }, CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.SearchParameter = null;
        
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

    private void SearchBar_SearchButtonPressed(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }
}