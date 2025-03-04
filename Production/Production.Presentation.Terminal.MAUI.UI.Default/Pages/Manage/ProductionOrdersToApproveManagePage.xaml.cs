using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class ProductionOrdersToApproveManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Models.Page.Manage.ProductionOrdersManagePageModel, Models.Page.Configuration.ProductionOrderConfigurationPageModel, Configuration.ProductionOrderConfigurationPage, Detail.ProductionOrderDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 180;

    public ProductionOrdersToApproveManagePage()
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

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.ProductionOrderDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.FilterPaginateAsync(new Interop.API.Common.Models.Filter.ProductionPlanFilterModel { Kind = Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.ToApprove }, CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override async System.Threading.Tasks.Task<Models.Page.Configuration.ProductionOrderConfigurationPageModel> FillConfigurationPageModelAsync(Interop.API.Common.Models.Display.ProductionOrderDisplayModel model = null)
    {
        var result = new Models.Page.Configuration.ProductionOrderConfigurationPageModel();

        var employeesAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var employees = await employeesAPIConnectClient.GetAsync();

        result.AvailableAuthors = employees;
        result.AvailableResponsibles = employees;
        result.AvailableDecisors = employees;

        return result;
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}