using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class ServiceOrderSamplesManagePage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel, Models.Page.Manage.ServiceOrderSamplesManagePageModel, Models.Page.Configuration.ServiceOrderSampleConfigurationPageModel>
{
    public ServiceOrderSamplesManagePage()
    {
        InitializeComponent();
    }

    protected override string ViewerPermissionCode => Interop.API.Common.Constants.Security.Authorization.ServiceOrderSampleViewerPermission;

    protected override string CreatorPermissionCode => Interop.API.Common.Constants.Security.Authorization.ServiceOrderSampleCreatorPermission;

    protected override string EditorPermissionCode => Interop.API.Common.Constants.Security.Authorization.ServiceOrderSampleEditorPermission;

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override bool ConfigurationRequiredAsyncWorkPresentation => true;

    protected override double ItemViewRequestWidth => Constants.CardViewHeightConstants.SAMPLE_DEFAULT_CARD_VIEW_WIDTH;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewHeightConstants.SAMPLE_DEFAULT_CARD_VIEW_HEIGHT;

    protected override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ServiceOrderSamplesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override void OnActionDelegationRequest(Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel target, int discriminator)
    {
        switch (discriminator)
        {
            case 0:
                var apiConnectClient = new Interop.API.Connect.Clients.ServiceOrderSamplesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.DeleteAsync(target.Id).ContinueWith(task =>
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