using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using Microsoft.Extensions.DependencyInjection;
using SkiaSharp;
using System.Linq;

namespace MOROPO.EPTCamaguey.Decisor.Terminal.MAUI.UI.Pages;

public partial class ServicingDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.Mock.ServicingDashboardMockPageModel>
{
    public ServicingDashboardPage() : base(new Models.Page.Mock.ServicingDashboardMockPageModel
    {
        LeasyTypeAreaChart = new Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.View.ChartViewModel(),
        PaymentProgressChart = new Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.View.ChartViewModel(),
        LatePaymentByClientHeatChart = new Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.View.ChartViewModel
        {
            XAxes = [
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labels = ["PescaSur-LAY", "TCP Rey", "CheffMIGUE S.R.L.", "PDL Co-Lab", "MOROPO S.U.R.L.", "Soldaduras Martínez", "TuKaza S.R.L."],
                    ForceStepToMin = true,
                    MinStep = 1
                }
            ],
            YAxes = [
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
                    ForceStepToMin = true,
                    MinStep = 1
                }
            ]
        }
    })
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContextPageModel.TenderCount = 3;
        BindingContextPageModel.LeaseCount = 41;
        BindingContextPageModel.ClientCount = 37;
        BindingContextPageModel.LeasyTypeAreaChart.Series = new[]
        {
            new LiveChartsCore.SkiaSharpView.PieSeries<int>
            {
                Values = new int[] { 14 },
                Name = "Inmuebles",
                Stroke = null
            },
            new LiveChartsCore.SkiaSharpView.PieSeries<int>
            {
                Values = new int[] { 27 },
                Name = "Vehículos",
                Stroke = null
            }
        };
        BindingContextPageModel.PaymentProgressChart.Series = GaugeGenerator.BuildSolidGauge(new GaugeItem(74, series =>
        {
            series.MaxRadialColumnWidth = 50;
            series.DataLabelsSize = 50;
        })).ToArray();
        BindingContextPageModel.LatePaymentByClientHeatChart.Series = new[]
        {
            new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint>
            {
                HeatMap = [
                    SKColors.LightGreen.AsLvcColor(), // the first element is the "coldest"
                    SKColors.SlateGray.AsLvcColor(),
                    SKColors.DarkRed.AsLvcColor() // the last element is the "hottest"
                ],
                Values = new LiveChartsCore.Defaults.WeightedPoint[] {
                    // Charles
                    new(0, 0, 3), // Jan
                    new(0, 1, 4), // Feb
                    new(0, 2, 2), // Mar
                    new(0, 3, 15), // Apr
                    new(0, 4, 28), // May
                    new(0, 5, 26), // Jun

                    // Richard
                    new(1, 0, 11), // Jan
                    new(1, 1, 12), // Feb
                    new(1, 2, 5), // Mar
                    new(1, 3, 24), // Apr
                    new(1, 4, 2), // May
                    new(1, 5, 4), // Jun

                    // Ana
                    new(2, 0, 4), // Jan
                    new(2, 1, 2), // Feb
                    new(2, 2, 1), // Mar
                    new(2, 3, 10), // Apr
                    new(2, 4, 7), // May
                    new(2, 5, 7), // Jun

                    // Mari
                    new(3, 0, 11), // Jan
                    new(3, 1, 27), // Feb
                    new(3, 2, 17), // Mar
                    new(3, 3, 28), // Apr
                    new(3, 4, 19), // May
                    new(3, 5, 10), // Jun

                    // Charles
                    new(4, 0, 3), // Jan
                    new(4, 1, 4), // Feb
                    new(4, 2, 2), // Mar
                    new(4, 3, 15), // Apr
                    new(4, 4, 28), // May
                    new(4, 5, 26), // Jun

                    // Richard
                    new(5, 0, 11), // Jan
                    new(5, 1, 12), // Feb
                    new(5, 2, 5), // Mar
                    new(5, 3, 24), // Apr
                    new(5, 4, 2), // May
                    new(5, 5, 4), // Jun

                    // Ana
                    new(6, 0, 4), // Jan
                    new(6, 1, 2), // Feb
                    new(6, 2, 1), // Mar
                    new(6, 3, 10), // Apr
                    new(6, 4, 7), // May
                    new(6, 5, 7), // Jun
                }
            }
        };
    }
}