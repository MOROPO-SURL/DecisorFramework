using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Manage;

public partial class OrganizationsManagePage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.OrganizationDisplayModel, Models.Page.Manage.OrganizationsManagePageModel, Models.Page.Configuration.OrganizationConfigurationPageModel, Configuration.OrganizationConfigurationPage, Detail.OrganizationDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 144;

    public OrganizationsManagePage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double ItemViewRequestWidth { get => 420; }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.OrganizationDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}