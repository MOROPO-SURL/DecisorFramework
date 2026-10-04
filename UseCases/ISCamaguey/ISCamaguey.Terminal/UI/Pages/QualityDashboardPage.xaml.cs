using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Connect.Clients;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Connect.Clients;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class QualityDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.QualityDashboardPageModel>
{
    private readonly IDispatcherTimer carouselTimer;

    private bool scrollToUp = true;

    public QualityDashboardPage() : base(new Models.Page.QualityDashboardPageModel
    {
        Images = [
            ImageSource.FromFile("quality_showcase_1.jpg"),
            ImageSource.FromFile("quality_showcase_2.jpg"),
            ImageSource.FromFile("quality_showcase_3.jpg"),
            ImageSource.FromFile("quality_showcase_4.jpg"),
            ImageSource.FromFile("quality_showcase_5.jpg")
        ],
        //LabRevisionMontlyChart = new Models.View.ChartViewModel
        //{
        //    XAxes = new LiveChartsCore.SkiaSharpView.Axis[]
        //    {
        //        new()
        //        {
        //            Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
        //            ForceStepToMin = true,
        //            MinStep = 1
        //        }
        //    }
        //},
        //ProductionRevisionMontlyChart = new Models.View.ChartViewModel
        //{
        //    XAxes = new LiveChartsCore.SkiaSharpView.Axis[]
        //    {
        //        new()
        //        {
        //            Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
        //            ForceStepToMin = true,
        //            MinStep = 1
        //        }
        //    }
        //}
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

        //LabRevisionMontlyChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        //ProductionRevisionMontlyChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
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

    private void Refresh()
    {
        if (BindingContextPageModel.IsBusy) return;

        BindingContextPageModel.IsBusy = true;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        CertificationsAPIConnectClient certificationAPIConnectClient = new(httpClientHelperProvider);
        IsoStandardsAPIConnectClient isoStandardAPIConnectClient = new(httpClientHelperProvider);
        CubanStandardsAPIConnectClient cubanStandardAPIConnectClient = new(httpClientHelperProvider);
        AnalysisQualityChecksAPIConnectClient analysisQualityChecksAPIConnectClient = new(httpClientHelperProvider);
        AssessmentQualityChecksAPIConnectClient assessmentQualityChecksAPIConnectClient = new(httpClientHelperProvider);
        ProductionQualityChecksAPIConnectClient productionQualityChecksAPIConnectClient = new(httpClientHelperProvider);

        var certificationCountTask = certificationAPIConnectClient.CountAsync();
        var isoStandardCountTask = isoStandardAPIConnectClient.CountAsync();
        var cubanStandardCountTask = cubanStandardAPIConnectClient.CountAsync();
        var analysisQualityCheckCountTask = analysisQualityChecksAPIConnectClient.CountAsync();
        var assessmentQualityCheckCountTask = assessmentQualityChecksAPIConnectClient.CountAsync();
        var productionQualityCheckCountTask = productionQualityChecksAPIConnectClient.CountAsync();

        System.Threading.Tasks.Task.WhenAll(certificationCountTask, isoStandardCountTask, cubanStandardCountTask, analysisQualityCheckCountTask, assessmentQualityCheckCountTask, productionQualityCheckCountTask).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.CertificationCount = certificationCountTask.Result;
                BindingContextPageModel.IsoStandardCount = isoStandardCountTask.Result;
                BindingContextPageModel.CubanStandardCount = cubanStandardCountTask.Result;
                BindingContextPageModel.LabRevisionCount = analysisQualityCheckCountTask.Result + assessmentQualityCheckCountTask.Result;
                BindingContextPageModel.ProductionRevisionCount = productionQualityCheckCountTask.Result;

                //BindingContextPageModel.IsLabRevisionMontlyChartMock = true;
                //BindingContextPageModel.LabRevisionMontlyChart.Series = new[]
                //{
                //    new LiveChartsCore.SkiaSharpView.StepLineSeries<double>
                //    {
                //        Values = new double[] { 10, 25, 21, 6, 18, 30 },
                //        Fill = null
                //    }
                //};
                //BindingContextPageModel.IsProductionRevisionMontlyChartMock = true;
                //BindingContextPageModel.ProductionRevisionMontlyChart.Series = new[]
                //{
                //    new LiveChartsCore.SkiaSharpView.StepLineSeries<double>
                //    {
                //        Values = new double[] { 18, 15, 12, 2, 2, 12 },
                //        Fill = null
                //    }
                //};

                BindingContextPageModel.IsBusy = false;
            });
        });
    }
}