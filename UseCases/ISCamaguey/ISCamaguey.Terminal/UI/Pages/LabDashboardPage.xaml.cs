using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Connect.Clients;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class LabDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.LabDashboardPageModel>
{
    private readonly IDispatcherTimer carouselTimer;

    private bool scrollToUp = true;

    public LabDashboardPage() : base(new Models.Page.LabDashboardPageModel
    {
        Images = [
            ImageSource.FromFile("lab_showcase_1.jpg"),
            ImageSource.FromFile("lab_showcase_2.jpg"),
            ImageSource.FromFile("lab_showcase_3.jpg"),
            ImageSource.FromFile("lab_showcase_4.jpg"),
            ImageSource.FromFile("lab_showcase_5.jpg")
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

    private async void GoSampleKindsAdminSiteManagePageButton_Clicked(object sender, System.EventArgs args)
    {
        await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}management/domain/samplekinds");
    }

    private async void GoUnitMeasurementsManageSiteButton_Clicked(object sender, System.EventArgs args)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.UnitMeasurementsManagePage).Name}"));
    }

    private async void GoTechniquesManageSiteButton_Clicked(object sender, System.EventArgs args)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.TechniquesManagePage).Name}"));
    }

    private async void GoWorkingGroupsManageSiteButton_Clicked(object sender, System.EventArgs args)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.WorkingGroupsManagePage).Name}"));
    }

    private void Refresh()
    {
        if (BindingContextPageModel.IsBusy) return;

        BindingContextPageModel.IsBusy = true;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        ResearchSamplesAPIConnectClient researchSamplesAPIConnectClient = new(httpClientHelperProvider);
        ServiceOrderSamplesAPIConnectClient serviceOrderSamplesAPIConnectClient = new(httpClientHelperProvider);
        ProductionSamplesAPIConnectClient productionSamplesAPIConnectClient = new(httpClientHelperProvider);
        AnalysesAPIConnectClient analysesAPIConnectClient = new(httpClientHelperProvider);
        AssessmentsAPIConnectClient assessmentsAPIConnectClient = new(httpClientHelperProvider);
        AnalysisQualityChecksAPIConnectClient analysisQualityChecksAPIConnectClient = new(httpClientHelperProvider);
        AssessmentQualityChecksAPIConnectClient assessmentQualityChecksAPIConnectClient = new(httpClientHelperProvider);
        WorkingGroupsAPIConnectClient workingGroupsAPIConnectClient = new(httpClientHelperProvider);
        WorkPlansAPIConnectClient workPlansAPIConnectClient = new(httpClientHelperProvider);
        TechniquesAPIConnectClient techniquesAPIConnectClient = new(httpClientHelperProvider);
        UnitMeasurementsAPIConnectClient unitMeasurementsAPIConnectClient = new(httpClientHelperProvider);
        SampleKindsAPIConnectClient sampleKindsAPIConnectClient = new(httpClientHelperProvider);

        var researchSampleCountTask = researchSamplesAPIConnectClient.CountAsync();
        var serviceOrderSampleCountTask = serviceOrderSamplesAPIConnectClient.CountAsync();
        var productionSampleCountTask = productionSamplesAPIConnectClient.CountAsync();
        var analysisCountTask = analysesAPIConnectClient.CountAsync();
        var assessmentCountTask = assessmentsAPIConnectClient.CountAsync();
        var analysisQualityCheckCountTask = analysisQualityChecksAPIConnectClient.CountAsync();
        var assessmentQualityCheckCountTask = assessmentQualityChecksAPIConnectClient.CountAsync();
        var workingGroupCountTask = workingGroupsAPIConnectClient.CountAsync();
        var workPlanCountTask = workPlansAPIConnectClient.CountAsync();
        var techniqueCountTask = techniquesAPIConnectClient.CountAsync();
        var unitMeasurementCountTask = unitMeasurementsAPIConnectClient.CountAsync();
        var sampleKindCountTask = sampleKindsAPIConnectClient.CountAsync();

        System.Threading.Tasks.Task.WhenAll(
            researchSampleCountTask,
            serviceOrderSampleCountTask,
            productionSampleCountTask,
            analysisCountTask,
            assessmentCountTask, 
            analysisQualityCheckCountTask, 
            assessmentQualityCheckCountTask,
            workingGroupCountTask,
            workPlanCountTask,
            techniqueCountTask,
            unitMeasurementCountTask,
            sampleKindCountTask).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.SampleCount = researchSampleCountTask.Result + serviceOrderSampleCountTask.Result + productionSampleCountTask.Result;
                BindingContextPageModel.AnalysisCount = analysisCountTask.Result;
                BindingContextPageModel.AssentmentCount = assessmentCountTask.Result;
                BindingContextPageModel.QualityCheckCount = analysisQualityCheckCountTask.Result + assessmentQualityCheckCountTask.Result;
                BindingContextPageModel.WorkGroupCount = workingGroupCountTask.Result;
                BindingContextPageModel.WorkPlanCount = workPlanCountTask.Result;
                BindingContextPageModel.UnitMeasurementCount = unitMeasurementCountTask.Result;
                BindingContextPageModel.TechniqueCount = techniqueCountTask.Result;
                BindingContextPageModel.SampleKindCount = sampleKindCountTask.Result;

                BindingContextPageModel.HasAnySampleKind = sampleKindCountTask.Result > 0;
                BindingContextPageModel.HasAnyUnitMeasurement = unitMeasurementCountTask.Result > 0;
                BindingContextPageModel.HasAnyTechnique = techniqueCountTask.Result > 0;
                BindingContextPageModel.HasAnyWorkingGroup = workingGroupCountTask.Result > 0;

                BindingContextPageModel.IsModuleReady =
                    BindingContextPageModel.HasAnySampleKind &&
                    BindingContextPageModel.HasAnyUnitMeasurement &&
                    BindingContextPageModel.HasAnyTechnique &&
                    BindingContextPageModel.HasAnyWorkingGroup;

                BindingContextPageModel.IsBusy = false;
            });
        });
    }
}