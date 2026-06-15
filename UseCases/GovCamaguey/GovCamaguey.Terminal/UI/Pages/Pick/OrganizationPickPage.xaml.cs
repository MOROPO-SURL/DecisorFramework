using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Pick;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Pick;

public partial class OrganizationPickPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<OrganizationDisplayModel, OrganizationPickPageModel>
{
    private System.Action<OrganizationDisplayModel> pickCompleteAction;

    public OrganizationPickPage(System.Action<OrganizationDisplayModel> pickCompleteAction)
    {
        InitializeComponent();

        this.pickCompleteAction = pickCompleteAction;
    }

    protected override double ItemViewRequestWidth => Constants.CardViewHeightConstants.ORGANIZATIONAL_DEFAULT_CARD_VIEW_WIDTH;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewHeightConstants.ORGANIZATIONAL_DEFAULT_CARD_VIEW_HEIGHT;

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<OrganizationDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }

    protected void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new Configuration.OrganizationConfigurationPage(ConfigurationSuccess_Callback, new Models.Page.Configuration.OrganizationConfigurationPageModel(null)));
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
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as OrganizationDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void ConfigurationSuccess_Callback(OrganizationDisplayModel model)
    {
        Dispatcher.Dispatch(() =>
        {
            pickCompleteAction.Invoke(model);

            pickCompleteAction = null;

            (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
        });
    }
}