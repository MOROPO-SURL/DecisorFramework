using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class LegalClientServicingContractPickPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, Models.Page.Pick.LegalClientServicingContractPickPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 228;

    private System.Action<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> pickCompleteAction;

    public LegalClientServicingContractPickPage(System.Action<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> pickCompleteAction)
    {
        InitializeComponent();

        this.pickCompleteAction = pickCompleteAction;
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double ItemViewRequestWidth => 460;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientServicingContractsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        if (!string.IsNullOrEmpty(ConcreteBindingContext.SearchParameter) && !string.IsNullOrWhiteSpace(ConcreteBindingContext.SearchParameter))
        {
            return apiConnectClient.FilterPaginateAsync(new Interop.API.Common.Models.Filter.LegalClientServicingContractFilterModel { ClientName = ConcreteBindingContext.SearchParameter }, CurrentItemsPageNumber, CurrentItemsPageLimit);
        }

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.SearchParameter = null;

        OnReload(sender, eventArgs);
    }

    protected void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
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
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void SearchBar_SearchButtonPressed(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }
}