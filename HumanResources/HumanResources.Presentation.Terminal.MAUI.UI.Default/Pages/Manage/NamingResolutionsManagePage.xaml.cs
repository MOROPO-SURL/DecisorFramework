using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class NamingResolutionsManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Models.Page.Manage.NamingResolutionsManagePageModel, Models.Page.Configuration.NamingResolutionConfigurationPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 268;

    private const string DIRECT_NAMING = "Directo";
    private const string CANDIDATE_NAMING = "Candidatura";

    public NamingResolutionsManagePage()
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

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.NamingResolutionDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync();
    }

    protected override void ComplementConfigurationPage(Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Models.Page.Configuration.NamingResolutionConfigurationPageModel> page, Interop.API.Common.Models.Display.NamingResolutionDisplayModel model)
    {
        page.ConcreteBindingContext.IsForOcupationCandidate = model.Candidate != null;
    }

    protected override void OnActionDelegationRequest(Interop.API.Common.Models.Display.NamingResolutionDisplayModel target, int discriminator)
    {
        switch (discriminator)
        {
            case 0:
                var apiConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
        DisplayActionSheet("Método de nombramiento", "Cancelar", null, DIRECT_NAMING, CANDIDATE_NAMING).ContinueWith(task =>
        {
            bool isForOcupationCandidate = false;

            switch (task.Result)
            {
                case DIRECT_NAMING:
                    isForOcupationCandidate = false;

                    break;

                case CANDIDATE_NAMING:
                    isForOcupationCandidate = true;

                    break;

                default:
                    return;
            }

            var concreteBindingContext = (Models.Page.Manage.NamingResolutionsManagePageModel)BindingContext;

            Dispatcher.Dispatch(() => concreteBindingContext.IsBusy = ConfigurationRequiredAsyncWorkPresentation);

            System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Models.Page.Configuration.NamingResolutionConfigurationPageModel>>();

                    var page = await factory.BuildAsync(ConfigurationSuccess_Callback, null);

                    page.ConcreteBindingContext.IsForOcupationCandidate = isForOcupationCandidate;

                    Dispatcher.Dispatch(() =>
                    {
                        concreteBindingContext.IsBusy = false;

                        this.NavigationPushPageAsync(page);
                    });
                }
                catch (System.Exception exception)
                {
                    Dispatcher.Dispatch(() =>
                    {
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                    });
                }
            });
        });        
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