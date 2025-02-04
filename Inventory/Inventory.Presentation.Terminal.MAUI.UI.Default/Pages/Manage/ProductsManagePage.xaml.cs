using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

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

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

        var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientHelperProvider);
        var familiesAPIConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(httpClientHelperProvider);

        // TODO complete fallow behavior
        //var warehousingDecreasesAPIConnectClient = new Web.API.Connect.Clients.WarehousingDecreasesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        result.AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync();
        result.AvailableCategories = await familiesAPIConnectClient.GetAsync();

        return result;
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}