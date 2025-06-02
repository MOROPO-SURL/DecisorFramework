using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class LegalProvidersManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.LegalProviderDisplayModel, Models.Page.Manage.LegalProvidersManagePageModel, Models.Page.Configuration.LegalProviderConfigurationPageModel, Configuration.LegalProviderConfigurationPage, Detail.LegalProviderDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 144;

    public LegalProvidersManagePage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double ItemViewRequestWidth { get => 420; }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.LegalProviderDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override async System.Threading.Tasks.Task<Models.Page.Configuration.LegalProviderConfigurationPageModel> FillConfigurationPageModelAsync(Interop.API.Common.Models.Display.LegalProviderDisplayModel model = null)
    {
        var result = new Models.Page.Configuration.LegalProviderConfigurationPageModel();

        var apiConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        result.AvailablePaymentTerms = await apiConnectClient.GetEnabledAsync();

        return result;
    }

    protected override void OnActionDelegationRequest(LegalProviderDisplayModel target, int discriminator)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        switch (discriminator)
        {
            case 0:
                var model = new Models.Page.Configuration.LegalProviderConfigurationPageModel(target);

                var paymentTermsAPIConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);

                paymentTermsAPIConnectClient.GetEnabledAsync().ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        model.AvailablePaymentTerms = task.Result;
                    }

                    Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.LegalProviderConfigurationPage(ConfigurationSuccess_Callback, model)));
                });

                break;
            case 1:
                var apiConnectClient = new Interop.API.Connect.Clients.LegalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.ArchiveAsync(target.Id).ContinueWith(task =>
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