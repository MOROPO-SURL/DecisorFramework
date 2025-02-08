using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class OrganizationContactsManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Models.Page.Manage.OrganizationContactsManagePageModel, Models.Page.Configuration.OrganizationContactConfigurationPageModel, Configuration.OrganizationContactConfigurationPage, Detail.OrganizationContactDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 132;

    public OrganizationContactsManagePage()
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

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.OrganizationContactDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationContactsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override async System.Threading.Tasks.Task<Models.Page.Configuration.OrganizationContactConfigurationPageModel> FillConfigurationPageModelAsync(Interop.API.Common.Models.Display.OrganizationContactDisplayModel model = null)
    {
        var result = new Models.Page.Configuration.OrganizationContactConfigurationPageModel();

        var apiConnectClient = new Interop.API.Connect.Clients.LegalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        result.AvailableBusinessKinds = await apiConnectClient.GetEnabledAsync();

        return result;
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}