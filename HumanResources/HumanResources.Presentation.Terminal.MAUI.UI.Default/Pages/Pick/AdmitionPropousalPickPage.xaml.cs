using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class AdmitionPropousalPickPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel, Models.Page.Pick.AdmitionPropousalPickPageModel, Detail.AdmitionPropousalDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 236;

    private System.Action<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel> pickCompleteAction;
    
    private readonly Interop.API.Common.Models.Display.WorkPositionDisplayModel workPosition;
    private readonly Interop.API.Common.Models.Display.StaffDisplayModel staff;

    public AdmitionPropousalPickPage(Interop.API.Common.Models.Display.WorkPositionDisplayModel workPosition, Interop.API.Common.Models.Display.StaffDisplayModel staff, System.Action<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel> pickCompleteAction)
    {
        InitializeComponent();

        this.pickCompleteAction = pickCompleteAction;
        this.workPosition = workPosition;
        this.staff = staff;
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double ItemViewRequestWidth => 520;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AdmitionPropousalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.FilterPaginateAsync(new Interop.API.Common.Models.Filter.AdmitionPropousalFilterModel { WorkPositionId = workPosition.Id, StaffId = staff.Id }, CurrentItemsPageNumber, CurrentItemsPageLimit);
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
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }
}