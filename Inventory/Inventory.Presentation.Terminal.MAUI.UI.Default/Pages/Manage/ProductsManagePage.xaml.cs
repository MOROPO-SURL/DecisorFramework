using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class ProductsManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.ProductDisplayModel, Models.Page.Manage.ProductsManagePageModel, Models.Page.Configuration.ProductConfigurationPageModel, Configuration.ProductConfigurationPage, Detail.ProductDetailPage>
{
    public ProductsManagePage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double ItemViewRequestWidth { get => 240; }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return width;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.ProductDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override async System.Threading.Tasks.Task<Models.Page.Configuration.ProductConfigurationPageModel> FillConfigurationPageModelAsync(Interop.API.Common.Models.Display.ProductDisplayModel model = null)
    {
        var result = new Models.Page.Configuration.ProductConfigurationPageModel();

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientHelperProvider);
        var familiesAPIConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(httpClientHelperProvider);

        // TODO complete fallow behavior
        //var warehousingDecreasesAPIConnectClient = new Web.API.Connect.Clients.WarehousingDecreasesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        result.AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync();
        result.AvailableCategories = await familiesAPIConnectClient.GetAsync();

        return result;
    }

    protected override void OnActionDelegationRequest(Interop.API.Common.Models.Display.ProductDisplayModel target, int discriminator)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        switch (discriminator)
        {
            case 0:
                var model = new Models.Page.Configuration.ProductConfigurationPageModel(target);

                System.Threading.Tasks.Task.Run(async () =>
                {
                    var familiesAPIConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(httpClientHelperProvider);
                    var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientHelperProvider);

                    return new { Families = await familiesAPIConnectClient.GetAsync(), UnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync() };

                }).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        model.AvailableCategories = task.Result.Families;
                        model.AvailableUnitMeasurements = task.Result.UnitMeasurements;
                    }

                    Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.ProductConfigurationPage(ConfigurationSuccess_Callback, model)));
                });

                break;
            case 1:
                var apiConnectClient = new Interop.API.Connect.Clients.ProductsAPIConnectClient(httpClientHelperProvider);

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