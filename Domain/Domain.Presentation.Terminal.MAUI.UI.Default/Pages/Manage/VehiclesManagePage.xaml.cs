using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class VehiclesManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.VehicleDisplayModel, Models.Page.Manage.VehiclesManagePageModel, Models.Page.Configuration.VehicleConfigurationPageModel, Configuration.VehicleConfigurationPage, Detail.VehicleDetailPage>
{
    public VehiclesManagePage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double ItemViewRequestWidth { get => 320; }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return width;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.VehicleDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehiclesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override async System.Threading.Tasks.Task<Models.Page.Configuration.VehicleConfigurationPageModel> FillConfigurationPageModelAsync(Interop.API.Common.Models.Display.VehicleDisplayModel model = null)
    {
        var result = new Models.Page.Configuration.VehicleConfigurationPageModel();

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var brandsAPIConnectClient = new Interop.API.Connect.Clients.BrandsAPIConnectClient(httpClientHelperProvider);
        var kindsAPIConnectClient = new Interop.API.Connect.Clients.VehicleKindsAPIConnectClient(httpClientHelperProvider);
        var engineKindsAPIConnectClient = new Interop.API.Connect.Clients.VehicleEngineKindsAPIConnectClient(httpClientHelperProvider);
        var structuresAPIConnectClient = new Interop.API.Connect.Clients.ParentalStructuresAPIConnectClient(httpClientHelperProvider);

        result.AvailableBrands = await brandsAPIConnectClient.GetEnabledAsync();
        result.AvailableKinds = await kindsAPIConnectClient.GetEnabledAsync();
        result.AvailableEngineKinds = await engineKindsAPIConnectClient.GetEnabledAsync();
        result.AvailableStructures = await structuresAPIConnectClient.GetEnabledAsync();

        return result;
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}