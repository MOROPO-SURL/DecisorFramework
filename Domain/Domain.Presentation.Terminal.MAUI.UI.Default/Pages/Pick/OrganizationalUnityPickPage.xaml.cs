using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class OrganizationalUnityPickPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel, Models.Page.Pick.OrganizationalUnityPickPageModel, Detail.OrganizationalUnityTreeDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 140;

    private System.Action<Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel> pickCompleteAction;

    private bool pickedFlag = false;

    public OrganizationalUnityPickPage(System.Action<Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel> pickCompleteAction)
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

    protected override double ItemViewRequestWidth => 384;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.TreeOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }

    private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
    {
        //var concreteBindingContext = BindingContext as Models.Page.Pick.OrganizationalUnityPickPageModel;

        //var apiConnectClient = new Interop.API.Connect.Clients.LegalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        //concreteBindingContext.IsBusy = true;

        //apiConnectClient.GetEnabledAsync().ContinueWith(task =>
        //{
        //    var model = new Models.Page.Configuration.OrganizationContactConfigurationPageModel
        //    {
        //        AvailableBusinessKinds = task.Result
        //    };

        //    Dispatcher.Dispatch(() =>
        //    {
        //        concreteBindingContext.IsBusy = false;

        //        this.NavigationPushPageAsync(new Configuration.OrganizationContactConfigurationPage(ConfigurationSuccess_Callback, model));
        //    });

        //});
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
        pickCompleteAction.Invoke(null);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void ConfigurationSuccess_Callback(Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel model)
    {
        Dispatcher.Dispatch(() => pickCompleteAction.Invoke(model));

        pickedFlag = true;
    }
}