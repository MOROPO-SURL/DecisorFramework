using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class NaturalProvidersManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Models.Page.Manage.NaturalProvidersManagePageModel, Models.Page.Configuration.NaturalProviderConfigurationPageModel, Configuration.NaturalProviderConfigurationPage, Detail.NaturalProviderDetailPage>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 144;

    public NaturalProvidersManagePage()
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

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.NaturalProviderDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    protected override async System.Threading.Tasks.Task<Models.Page.Configuration.NaturalProviderConfigurationPageModel> FillConfigurationPageModelAsync(Interop.API.Common.Models.Display.NaturalProviderDisplayModel model = null)
    {
        var result = new Models.Page.Configuration.NaturalProviderConfigurationPageModel();

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var paymentTermsAPIConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);
        var businessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(httpClientHelperProvider);

        result.AvailablePaymentTerms = await paymentTermsAPIConnectClient.GetEnabledAsync();
        result.AvailableBusinessKinds = await businessKindsAPIConnectClient.GetEnabledAsync();

        return result;
    }

    protected override void OnActionDelegationRequest(NaturalProviderDisplayModel target, int discriminator)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        switch (discriminator)
        {
            case 0:
                var model = new Models.Page.Configuration.NaturalProviderConfigurationPageModel(target);

                var paymentTermsAPIConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);
                var naturalBusinessKindAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(httpClientHelperProvider);

                System.Threading.Tasks.Task.Run(async () =>
                {
                    var paymentTermsAPIConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);
                    var naturalBusinessKindAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(httpClientHelperProvider);

                    return new { PaymentTerms = await paymentTermsAPIConnectClient.GetEnabledAsync(), BusinessKinds = await naturalBusinessKindAPIConnectClient.GetEnabledAsync() };

                }).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        model.AvailablePaymentTerms = task.Result.PaymentTerms;
                        model.AvailableBusinessKinds = task.Result.BusinessKinds;
                    }

                    Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.NaturalProviderConfigurationPage(ConfigurationSuccess_Callback, model)));
                });

                break;
            case 1:
                var apiConnectClient = new Interop.API.Connect.Clients.NaturalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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