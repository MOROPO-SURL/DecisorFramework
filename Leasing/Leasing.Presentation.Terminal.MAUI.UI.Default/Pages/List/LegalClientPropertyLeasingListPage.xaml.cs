using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.List;

public partial class LegalClientPropertyLeasingListPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<LegalClientPropertyLeasingDisplayModel, Models.Page.List.LegalClientPropertyLeasingListPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 236;

    public LegalClientPropertyLeasingListPage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double ItemViewRequestWidth { get => 400; }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<LegalClientPropertyLeasingDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientPropertyLeasingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync();
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
        var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<LegalClientPropertyLeasingDisplayModel>>();

        try
        {
            var page = factory.Build((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as LegalClientPropertyLeasingDisplayModel, DetailActionDelegationRequest_Callback);

            this.NavigationPushModalPageAsync(page);
        }
        catch (System.Exception exception)
        {
            DisplayAlert("Aviso", string.Format("Unspected runtime error!! {0}", exception.Message), "Aceptar");

            return;
        }
    }

    private void DetailActionDelegationRequest_Callback(LegalClientPropertyLeasingDisplayModel target, int? discriminator)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientPropertyLeasingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.ArchiveAsync(target.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Elemento eliminado con éxito.");

                LoadItems(true);
            });
        });
    }
}