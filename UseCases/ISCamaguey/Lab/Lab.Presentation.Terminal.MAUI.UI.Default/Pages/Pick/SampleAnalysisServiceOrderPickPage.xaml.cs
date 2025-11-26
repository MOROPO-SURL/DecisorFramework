using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class SampleAnalysisServiceOrderPickPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel, Models.Page.Pick.SampleAnalysisServiceOrderPickPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 192;

    private System.Action<Interop.API.Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel> pickCompleteAction;

    public SampleAnalysisServiceOrderPickPage(System.Action<Interop.API.Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel> pickCompleteAction)
    {
        InitializeComponent();

        this.pickCompleteAction = pickCompleteAction;
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double ItemViewRequestWidth => 420;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SampleAnalysisServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }
}