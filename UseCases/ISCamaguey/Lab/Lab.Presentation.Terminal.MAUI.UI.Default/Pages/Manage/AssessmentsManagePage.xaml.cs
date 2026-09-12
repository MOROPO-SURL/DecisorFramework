using Microsoft.Extensions.DependencyInjection;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.View;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class AssessmentsManagePage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Models.View.AssessmentDetailViewModel, Models.Page.Manage.AssessmentsManagePageModel, Models.Page.Configuration.AssessmentConfigurationPageModel>
{
    public AssessmentsManagePage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override bool DetailRequiredAsyncWorkPresentation => true;

    protected override double ItemViewRequestWidth => Constants.CardViewHeightConstants.ASSESSMENT_DEFAULT_CARD_VIEW_WIDTH;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewHeightConstants.ASSESSMENT_DEFAULT_CARD_VIEW_HEIGHT;

    protected async override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<Models.View.AssessmentDetailViewModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AssessmentsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var result = await apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);

        return new Framework.Guama.Core.Presentation.Models.PaginationModel<Models.View.AssessmentDetailViewModel>
        {
            Page = result.Page,
            HasNext = result.HasNext,
            HasPrevious = result.HasPrevious,
            Limit = result.Limit,
            MaxPageCount = result.MaxPageCount,
            List = [.. result.List.Select(item => new Models.View.AssessmentDetailViewModel(item, []))]
        };
    }

    protected override void OnActionDelegationRequest(Models.View.AssessmentDetailViewModel target, int discriminator)
    {
        switch (discriminator)
        {
            case 0:
                var apiConnectClient = new Interop.API.Connect.Clients.AssessmentsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.ArchiveAsync(target.Target.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });

                break;

            default:
                throw new System.InvalidOperationException();
        }
    }

    protected async override System.Threading.Tasks.Task<AssessmentDetailViewModel> FillItemDataAsync(AssessmentDetailViewModel model)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        Interop.API.Connect.Clients.AnalysesAPIConnectClient analysesAPIConnectClient = new(httpClientHelperProvider);
        Interop.API.Connect.Clients.AnalysisQualityChecksAPIConnectClient analysisQualityChecksAPIConnectClient = new(httpClientHelperProvider);

        var details = new List<AnalysisDetailViewModel>();

        if (model != null)
        {
            var analyses = await analysesAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.AnalysisFilterModel { SampleId = model.Target.Sample.Id });

            foreach (var analisis in analyses)
            {
                details.Add(new AnalysisDetailViewModel(analisis, await analysisQualityChecksAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.AnalysisQualityCheckFilterModel { AnalysisId = analisis.Id })));
            }
        };

        return new AssessmentDetailViewModel(model.Target, details);
    }

    private void AddItemToolbarItems_Clicked(object sender, System.EventArgs args)
    {
        AddItem(sender, args);
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs args)
    {
        ConcreteBindingContext.SearchParameter = null;

        OnReload(sender, args);
    }

    private void LoadMoreBurron_Clicked(object sender, System.EventArgs args)
    {
        OnLoadMore(sender, args);
    }

    private void ItemsCollectionViewLayout_SizeChanged(object sender, System.EventArgs args)
    {
        OnItemsCollectionViewLayoutResize(sender, args);
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs args)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}