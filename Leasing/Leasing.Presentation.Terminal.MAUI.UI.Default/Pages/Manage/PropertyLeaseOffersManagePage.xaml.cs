using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class PropertyLeaseOffersManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Models.Page.Manage.PropertyLeaseOffersManagePageModel, Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel, Configuration.PropertyLeaseOfferConfigurationPage, Detail.PropertyLeaseOfferDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 272;

    public PropertyLeaseOffersManagePage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double ItemViewRequestWidth { get => 400; }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeaseOffersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override System.Threading.Tasks.Task<Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel> GetConfigurationPageModelAsync(Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel model = null)
    {
        return System.Threading.Tasks.Task.FromResult(new Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel(model));
    }

    protected override void OnActionDelegationRequest(Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel target, int discriminator)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        switch (discriminator)
        {
            case 0:
                var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeaseOffersAPIConnectClient(httpClientHelperProvider);

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