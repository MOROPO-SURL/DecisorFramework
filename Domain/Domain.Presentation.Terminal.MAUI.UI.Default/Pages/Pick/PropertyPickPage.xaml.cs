using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class PropertyPickPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.PropertyDisplayModel, Models.Page.Pick.PropertyPickPageModel, Detail.PropertyDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 320;

    private System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel> pickCompleteAction;

    private bool pickedFlag = false;

    public PropertyPickPage(System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel> pickCompleteAction)
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

    protected override double ItemViewRequestWidth => 320;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.PropertyDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }

    private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new Configuration.PropertyConfigurationPage(ConfigurationSuccess_Callback, new Models.Page.Configuration.PropertyConfigurationPageModel(null)));
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
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PropertyDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void ConfigurationSuccess_Callback(Interop.API.Common.Models.Display.PropertyDisplayModel model)
    {
        Dispatcher.Dispatch(() => pickCompleteAction.Invoke(model));

        pickedFlag = true;
    }
}