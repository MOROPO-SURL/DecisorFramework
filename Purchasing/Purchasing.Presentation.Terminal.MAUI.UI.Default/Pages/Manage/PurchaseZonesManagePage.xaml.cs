using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class PurchaseZonesManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Models.Page.Manage.PurchaseZonesManagePageModel, Models.Page.Configuration.PurchaseZoneConfigurationPageModel, Configuration.PurchaseZoneConfigurationPage, Detail.PurchaseZoneDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 132;

    public PurchaseZonesManagePage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double ItemViewRequestWidth { get => 384; }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override System.Threading.Tasks.Task<Models.Page.Configuration.PurchaseZoneConfigurationPageModel> GetConfigurationPageModelAsync(Interop.API.Common.Models.Display.PurchaseZoneDisplayModel model = null)
    {
        return System.Threading.Tasks.Task.FromResult(new Models.Page.Configuration.PurchaseZoneConfigurationPageModel(model));
    }

    protected override void OnActionDelegationRequest(Interop.API.Common.Models.Display.PurchaseZoneDisplayModel target, int discriminator)
    {
        switch (discriminator)
        {
            case 0:
                var apiConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.ArchiveAsync(target.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });

                break;

            default:
                throw new System.InvalidOperationException();
        }
    }

    private void AddItemToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        AddItem(sender, eventArgs);
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