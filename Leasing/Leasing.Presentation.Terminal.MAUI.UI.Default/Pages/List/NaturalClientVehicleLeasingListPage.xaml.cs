using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.List;

public partial class NaturalClientVehicleLeasingListPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<NaturalClientVehicleLeasingDisplayModel, Models.Page.List.NaturalClientVehicleLeasingListPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 236;

    public NaturalClientVehicleLeasingListPage()
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

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<NaturalClientVehicleLeasingDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
        if (ConcreteBindingContext.IsBusy) return;

        var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<NaturalClientVehicleLeasingDisplayModel>>();

        try
        {
            var page = factory.Build((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as NaturalClientVehicleLeasingDisplayModel, DetailActionDelegationRequest_Callback);

            this.NavigationPushModalPageAsync(page);
        }
        catch (System.Exception exception)
        {
            DisplayAlert("Aviso", string.Format("Unspected runtime error!! {0}", exception.Message), "Aceptar");

            return;
        }
    }

    private void DetailActionDelegationRequest_Callback(NaturalClientVehicleLeasingDisplayModel target, int? discriminator)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.ArchiveAsync(target.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Arrendamiento terminado y contrato cerrado con éxito.");

                LoadItems(true);
            });
        });
    }
}
