using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class IDiDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.IDiDashboardPageModel>
{
    private readonly IDispatcherTimer carouselTimer;

    private bool scrollToUp = true;

    public IDiDashboardPage() : base(new Models.Page.IDiDashboardPageModel
    {
        Images = [
            ImageSource.FromFile("research_showcase_1.jpg"),
            ImageSource.FromFile("research_showcase_2.jpg"),
            ImageSource.FromFile("research_showcase_3.jpg"),
            ImageSource.FromFile("research_showcase_4.jpg"),
            ImageSource.FromFile("research_showcase_5.jpg")
        ]
    })
    {
        InitializeComponent();

        carouselTimer = Dispatcher.CreateTimer();

        carouselTimer.Interval = System.TimeSpan.FromSeconds(5);

        carouselTimer.Tick += (sender, args) =>
        {
            if (BindingContext == null) return;

            Dispatcher.Dispatch(() =>
            {
                scrollToUp = MainCarouselView.Position switch
                {
                    0 => true,
                    4 => false,
                    _ => scrollToUp
                };

                var carouselNextIndex = scrollToUp ? MainCarouselView.Position + 1 : MainCarouselView.Position - 1;

                System.Diagnostics.Debug.WriteLine($"Scrolled from {MainCarouselView.Position} to {carouselNextIndex}");

                MainCarouselView.ScrollTo(carouselNextIndex);
            });
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        carouselTimer.Start();

        Refresh();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        carouselTimer.Stop();
    }

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        carouselTimer.Stop();
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        Refresh();
    }

    private async void GoAwardKindsManageSiteButton_Clicked(object sender, System.EventArgs args)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.AwardKindsManagePage).Name}"));
    }

    private async void GoScientificTechnicalResultKindsManageSiteButton_Clicked(object sender, System.EventArgs args)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.ScientificTechnicalResultKindsManagePage).Name}"));
    }

    private async void GoProgramKindsAdminSiteManagePageButton_Clicked(object sender, System.EventArgs args)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/idi/programkinds");
    }

    private async void GoProjectCategoriesAdminSiteManagePageButton_Clicked(object sender, System.EventArgs args)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/idi/projectcategories");
    }

    private async void GoResearcherCategoriesAdminSiteManagePageButton_Clicked(object sender, System.EventArgs args)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/idi/researchercategories");
    }

    private async void GoTeachingCategoriesAdminSiteManagePageButton_Clicked(object sender, System.EventArgs args)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/idi/teachingcategories");
    }

    private void Refresh()
    {
        if (BindingContextPageModel.IsBusy) return;

        BindingContextPageModel.IsBusy = true;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        CallForProposalsAPIConnectClient callForProposalsAPIConnectClient = new(httpClientHelperProvider);
        ProjectsAPIConnectClient projectsAPIConnectClient = new(httpClientHelperProvider);
        ScientificTechnicalResultIntroductionsAPIConnectClient scientificTechnicalResultIntroductionsAPIConnectClient = new(httpClientHelperProvider);
        PublicationResultsAPIConnectClient publicationResultsAPIConnectClient = new(httpClientHelperProvider);
        ThesisResultsAPIConnectClient thesisResultsAPIConnectClient = new(httpClientHelperProvider);
        AwardResultsAPIConnectClient awardResultsAPIConnectClient = new(httpClientHelperProvider);
        ScientificTechnicalResultsAPIConnectClient scientificTechnicalResultsAPIConnectClient = new(httpClientHelperProvider);
        ProgramsAPIConnectClient programsAPIConnectClient = new(httpClientHelperProvider);
        ParticipatingOrganizationsAPIConnectClient participatingOrganizationsAPIConnectClient = new(httpClientHelperProvider);
        InternalResearchersAPIConnectClient internalResearchersAPIConnectClient = new(httpClientHelperProvider);
        ExternalResearchersAPIConnectClient externalResearchersAPIConnectClient = new(httpClientHelperProvider);
        FinanciersAPIConnectClient financiersAPIConnectClient = new(httpClientHelperProvider);
        AwardKindsAPIConnectClient awardKindsAPIConnectClient = new(httpClientHelperProvider);
        ScientificTechnicalResultKindsAPIConnectClient scientificTechnicalResultKindsAPIConnectClient = new(httpClientHelperProvider);
        ProgramKindsAPIConnectClient programKindsAPIConnectClient = new(httpClientHelperProvider);
        ProjectCategoriesAPIConnectClient projectCategoriesAPIConnectClient = new(httpClientHelperProvider);
        ResearcherCategoriesAPIConnectClient researcherCategoriesAPIConnectClient = new(httpClientHelperProvider);
        TeachingCategoriesAPIConnectClient teachingCategoriesAPIConnectClient = new(httpClientHelperProvider);

        var callForProposalCountTask = callForProposalsAPIConnectClient.CountAsync();
        var projectCountTask = projectsAPIConnectClient.CountAsync();
        var scientificTechnicalResultIntroductionCountTask = scientificTechnicalResultIntroductionsAPIConnectClient.CountAsync();
        var publicationResultCountTask = publicationResultsAPIConnectClient.CountAsync();
        var thesisResultCountTask = thesisResultsAPIConnectClient.CountAsync();
        var awardResultCountTask = awardResultsAPIConnectClient.CountAsync();
        var scientificTechnicalResultCountTask = scientificTechnicalResultsAPIConnectClient.CountAsync();
        var programCountTask = programsAPIConnectClient.CountAsync();
        var participatingOrganizationCountTask = participatingOrganizationsAPIConnectClient.CountAsync();
        var internalResearcherCountTask = internalResearchersAPIConnectClient.CountAsync();
        var externalResearcherCountTask = externalResearchersAPIConnectClient.CountAsync();
        var financierCountTask = financiersAPIConnectClient.CountAsync();
        var awardKindCountTask = awardKindsAPIConnectClient.CountAsync();
        var scientificTechnicalResultKindCountTask = scientificTechnicalResultKindsAPIConnectClient.CountAsync();
        var programKindCountTask = programKindsAPIConnectClient.CountAsync();
        var projectCategoryCountTask = projectCategoriesAPIConnectClient.CountAsync();
        var researcherCategoryCountTask = researcherCategoriesAPIConnectClient.CountAsync();
        var teachingCategoryCountTask = teachingCategoriesAPIConnectClient.CountAsync();

        System.Threading.Tasks.Task.WhenAll(
            callForProposalCountTask,
            projectCountTask,
            scientificTechnicalResultIntroductionCountTask,
            publicationResultCountTask,
            thesisResultCountTask,
            awardResultCountTask,
            scientificTechnicalResultCountTask,
            programCountTask,
            participatingOrganizationCountTask,
            internalResearcherCountTask,
            externalResearcherCountTask,
            financierCountTask,
            awardKindCountTask,
            scientificTechnicalResultKindCountTask,
            programKindCountTask,
            projectCategoryCountTask,
            researcherCategoryCountTask,
            teachingCategoryCountTask).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    BindingContextPageModel.CallForPropousalCount = callForProposalCountTask.Result;
                    BindingContextPageModel.ProjectCount = projectCountTask.Result;
                    BindingContextPageModel.ScientificTechnicalResultIntroductionCount = scientificTechnicalResultIntroductionCountTask.Result;
                    BindingContextPageModel.PublicationCount = publicationResultCountTask.Result;
                    BindingContextPageModel.ThesisCount = thesisResultCountTask.Result;
                    BindingContextPageModel.AwardCount = awardResultCountTask.Result;
                    BindingContextPageModel.ScientificTechnicalResultCount = scientificTechnicalResultCountTask.Result;
                    BindingContextPageModel.ProgramCount = programCountTask.Result;
                    BindingContextPageModel.ParticipatingOrganizationCount = participatingOrganizationCountTask.Result;
                    BindingContextPageModel.ResearcherCount = internalResearcherCountTask.Result + externalResearcherCountTask.Result;
                    BindingContextPageModel.FinancierCount = financierCountTask.Result;
                    
                    BindingContextPageModel.HasAnyAwardKind = awardKindCountTask.Result > 0;
                    BindingContextPageModel.HasAnyScientificTechnicalResultKind = scientificTechnicalResultKindCountTask.Result > 0;
                    BindingContextPageModel.HasAnyProgramKind = programKindCountTask.Result > 0;
                    BindingContextPageModel.HasAnyProjectCategory = projectCategoryCountTask.Result > 0;
                    BindingContextPageModel.HasAnyResearcherCategory = researcherCategoryCountTask.Result > 0;
                    BindingContextPageModel.HasAnyTeachingCategory = teachingCategoryCountTask.Result > 0;

                    BindingContextPageModel.IsModuleReady =
                        BindingContextPageModel.HasAnyAwardKind &&
                        BindingContextPageModel.HasAnyScientificTechnicalResultKind &&
                        BindingContextPageModel.HasAnyProgramKind &&
                        BindingContextPageModel.HasAnyProjectCategory &&
                        BindingContextPageModel.HasAnyResearcherCategory &&
                        BindingContextPageModel.HasAnyTeachingCategory;

                    BindingContextPageModel.IsBusy = false;
                });
            });
    }
}