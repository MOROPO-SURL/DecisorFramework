using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class VehicleLeaseOffersToApproveManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Models.Page.Manage.VehicleLeaseOffersManagePageModel, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel, Configuration.VehicleLeaseOfferConfigurationPage, Detail.VehicleLeaseOfferDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 180;

    public VehicleLeaseOffersToApproveManagePage()
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

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOffersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.FilterPaginateAsync(new Interop.API.Common.Models.Filter.VehicleLeaseOfferFilterModel { Kind = Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.ToApprove }, CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override System.Threading.Tasks.Task<Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel> GetConfigurationPageModelAsync(Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel model = null)
    {
        return System.Threading.Tasks.Task.FromResult(new Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel(model));
    }

    protected override void OnActionDelegationRequest(Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel target, int discriminator)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        switch (discriminator)
        {
            case 0:
                var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOffersAPIConnectClient(httpClientHelperProvider);

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