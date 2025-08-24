using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class OcupationCandidatePickPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel, Models.Page.Pick.OcupationCandidatePickPageModel, Detail.OcupationCandidateDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 208;

    private System.Action<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel> pickCompleteAction;

    private bool pickedFlag = false;

    public OcupationCandidatePickPage(System.Action<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel> pickCompleteAction)
    {
        InitializeComponent();

        this.pickCompleteAction = pickCompleteAction;

        IsEnabled = false;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled && pickedFlag)
        {
            (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();

            return;
        }

        IsEnabled = true;
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

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OcupationCandidatesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.OcupationCandidateDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }
}