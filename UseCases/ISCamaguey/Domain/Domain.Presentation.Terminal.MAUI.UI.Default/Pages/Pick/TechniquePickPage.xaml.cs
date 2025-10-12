using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class TechniquePickPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Interop.API.Common.Models.Display.TechniqueDisplayModel, Models.Page.Pick.TechniquePickPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 136;

    private readonly Interop.API.Common.Models.Filter.TechniqueFilterModel filter;

    private System.Action<Interop.API.Common.Models.Display.TechniqueDisplayModel> pickCompleteAction;

    private bool pickedFlag = false;

    public TechniquePickPage(System.Action<Interop.API.Common.Models.Display.TechniqueDisplayModel> pickCompleteAction, Interop.API.Common.Models.Filter.TechniqueFilterModel filter = null)
    {
        InitializeComponent();

        this.pickCompleteAction = pickCompleteAction;
        this.filter = filter;

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

    protected override double ItemViewRequestWidth => 360;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return ITEM_VIEW_REQUEST_HEIGHT;
    }

    protected override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.TechniqueDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.TechniquesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        if (filter != null) return apiConnectClient.FilterPaginateAsync(filter, CurrentItemsPageNumber, CurrentItemsPageLimit);

        return apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }

    private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = BindingContext as Models.Page.Pick.TechniquePickPageModel;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.TechniqueDisplayModel, Models.Page.Configuration.TechniqueConfigurationPageModel>>();

                var page = await factory.BuildAsync(ConfigurationSuccess_Callback, null);

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
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);

                    concreteBindingContext.IsBusy = false;
                });
            }
        });
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
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.TechniqueDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void ConfigurationSuccess_Callback(Interop.API.Common.Models.Display.TechniqueDisplayModel model)
    {
        Dispatcher.Dispatch(() => pickCompleteAction.Invoke(model));

        pickedFlag = true;
    }
}