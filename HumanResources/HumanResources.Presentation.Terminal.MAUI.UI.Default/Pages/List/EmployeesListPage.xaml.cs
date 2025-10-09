using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.List;

public partial class EmployeesListPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Models.Page.Detail.EmployeeDetailPageModel, Models.Page.List.EmployeesListPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 140;

    public EmployeesListPage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override bool DetailRequiredAsyncWorkPresentation => true;

    protected override double ItemViewRequestWidth { get => 384; }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }


    protected override async System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Models.Page.Detail.EmployeeDetailPageModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var result = await apiConnectClient.GetPaginateAsync();

        return new Guama.Core.Presentation.Models.PaginationModel<Models.Page.Detail.EmployeeDetailPageModel>
        {
            HasNext = result.HasNext,
            HasPrevious = result.HasPrevious,
            Limit = result.Limit,
            MaxPageCount = result.MaxPageCount,
            Page = result.Page,
            List = result.List.Select(item => new Models.Page.Detail.EmployeeDetailPageModel { Domain = item }).ToList()
        };
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


    protected override async System.Threading.Tasks.Task<Models.Page.Detail.EmployeeDetailPageModel> FillItemDataAsync(Models.Page.Detail.EmployeeDetailPageModel model)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var namingEmploymentContractsAPIConnectClient = new Interop.API.Connect.Clients.NamingEmploymentContractsAPIConnectClient(httpClientHelperProvider);
        var admitionEmploymentContractsAPIConnectClient = new Interop.API.Connect.Clients.AdmitionEmploymentContractsAPIConnectClient(httpClientHelperProvider);

        var list = new System.Collections.Generic.List<Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<int>>();

        list.AddRange(await namingEmploymentContractsAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.NamingEmploymentContractFilterModel { EmployeeId = model.Domain.Id }));
        list.AddRange(await admitionEmploymentContractsAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.AdmitionEmploymentContractFilterModel { EmployeeId = model.Domain.Id }));

        model.EmploymentContracts = [.. list.OrderBy(_model => _model.Priority)];

        await model.FillDailyCheckingsAsync();

        return model;
    }
}