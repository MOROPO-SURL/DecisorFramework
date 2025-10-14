using CommunityToolkit.Maui.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class QualityDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.QualityDashboardPageModel>
{
    public QualityDashboardPage() : base(new Models.Page.QualityDashboardPageModel
    {
        LabRevisionMontlyChart = new Models.View.ChartViewModel
        {
            XAxes = new LiveChartsCore.SkiaSharpView.Axis[]
            {
                new()
                {
                    Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
                    ForceStepToMin = true,
                    MinStep = 1
                }
            }
        },
        ProductionRevisionMontlyChart = new Models.View.ChartViewModel
        {
            XAxes = new LiveChartsCore.SkiaSharpView.Axis[]
            {
                new()
                {
                    Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
                    ForceStepToMin = true,
                    MinStep = 1
                }
            }
        }
    })
    {
        InitializeComponent();

        LabRevisionMontlyChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        ProductionRevisionMontlyChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Refresh();
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        Refresh();
    }

    private void Refresh()
    {
        if (BindingContextPageModel.IsBusy) return;

        BindingContextPageModel.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var isoStandardAPIConnectClient = new Quality.Interop.API.Connect.Clients.IsoStandardsAPIConnectClient(httpClientHelperProvider);
            var cuabnStandardAPIConnectClient = new Quality.Interop.API.Connect.Clients.CubanStandardsAPIConnectClient(httpClientHelperProvider);

            var isoStandardCount = await isoStandardAPIConnectClient.CountAsync();
            var cubanStandardCount = await cuabnStandardAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.IsoStandardCount = isoStandardCount;
                BindingContextPageModel.CubanStandardCount = cubanStandardCount;
                BindingContextPageModel.IsLabRevisionMontlyChartMock = true;
                BindingContextPageModel.LabRevisionMontlyChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.StepLineSeries<double>
                    {
                        Values = new double[] { 10, 25, 21, 6, 18, 30 },
                        Fill = null
                    }
                };
                BindingContextPageModel.IsProductionRevisionMontlyChartMock = true;
                BindingContextPageModel.ProductionRevisionMontlyChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.StepLineSeries<double>
                    {
                        Values = new double[] { 18, 15, 12, 2, 2, 12 },
                        Fill = null
                    }
                };
                BindingContextPageModel.IsBusy = false;
            });
        });
    }
}