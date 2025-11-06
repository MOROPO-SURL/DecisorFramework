using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class NaturalClientsManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.NaturalClientDisplayModel, Models.Page.Manage.NaturalClientsManagePageModel, Models.Page.Configuration.NaturalClientConfigurationPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 144;

    public NaturalClientsManagePage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override bool ConfigurationRequiredAsyncWorkPresentation => true;

    protected override double ItemViewRequestWidth { get => 420; }

    protected override string ViewerPermissionCode => Interop.API.Common.Constants.Security.Authorization.NaturalClientViewerPermission;

    protected override string CreatorPermissionCode => Interop.API.Common.Constants.Security.Authorization.NaturalClientCreatorPermission;

    protected override string EditorPermissionCode => Interop.API.Common.Constants.Security.Authorization.NaturalClientEditorPermission;

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.NaturalClientDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        if (!string.IsNullOrEmpty(ConcreteBindingContext.SearchParameter) && !string.IsNullOrWhiteSpace(ConcreteBindingContext.SearchParameter))
        {
            return apiConnectClient.FilterPaginateAsync(new Interop.API.Common.Models.Filter.NaturalClientFilterModel { Parameter = ConcreteBindingContext.SearchParameter }, CurrentItemsPageNumber, CurrentItemsPageLimit);
        }

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override void OnActionDelegationRequest(Interop.API.Common.Models.Display.NaturalClientDisplayModel target, int discriminator)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        switch (discriminator)
        {
            case 0:
                var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.ArchiveAsync(target.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() =>
                    {
                        CommunityToolkit.Maui.Alerts.Toast.Make("Elemento eliminado con éxito.").Show();

                        LoadItems(true);
                    });
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
        ConcreteBindingContext.SearchParameter = null;

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

    private void SearchBar_SearchButtonPressed(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }
}