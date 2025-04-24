using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Manage;

public partial class PersonsManagePage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.PersonDisplayModel, Models.Page.Manage.PersonsManagePageModel, Models.Page.Configuration.PersonConfigurationPageModel, Configuration.PersonConfigurationPage, Detail.PersonDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 132;

    public PersonsManagePage()
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

    protected override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.PersonDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PersonsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}