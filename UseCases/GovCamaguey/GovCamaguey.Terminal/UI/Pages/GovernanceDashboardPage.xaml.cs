using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages;

public partial class GovernanceDashboardPage : Microsoft.Maui.Controls.ContentPage
{
	public GovernanceDashboardPage()
	{
		InitializeComponent();

        GlobalObjectivesStatusPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        GlobalObjectivesStatusPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        ProyectionDistributionPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        ActionDistributionPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        IndicatorDistributionPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));

        BindingContext = new Models.Page.GovernanceDashboardPageModel()
        {
            GlobalObjectivesStatusChart = new Models.View.ChartViewModel(),
            MonthlyObjectivesProgressChart = new Models.View.ChartViewModel
            {
                YAxes = [
                    new LiveChartsCore.SkiaSharpView.Axis
                    {
                        Labels = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
                        ForceStepToMin = true,
                        MinStep = 1
                    }
                ]
            },
            ProyectionDistributionChart = new Models.View.ChartViewModel(),
            ActionDistributionChart = new Models.View.ChartViewModel(),
            IndicatorDistributionChart = new Models.View.ChartViewModel()
        };

        IsEnabled = false;
    }

    private Models.Page.GovernanceDashboardPageModel ConcreteBindingContext { get => BindingContext as Models.Page.GovernanceDashboardPageModel; }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled) return;

        IsEnabled = true;

        ReloadToolbarItem_Clicked(this, System.EventArgs.Empty);
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (ConcreteBindingContext.IsBusy) return;

        var glyphs = new char[] { '\uF05D', '\uF05C', '\uF045', '\uF042', '\uF84E' };

        var randomizer = new System.Random();

        ConcreteBindingContext.IsBusy = true;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var objectivesAPIConnectClient = new Interop.API.Connect.Clients.ObjectivesAPIConnectClient(httpClientHelperProvider);
        var resultsAPIConnectClient = new Interop.API.Connect.Clients.ActionIndicatorResultsAPIConnectClient(httpClientHelperProvider);

        objectivesAPIConnectClient.GetAsync().ContinueWith(async task =>
        {
            if (task.Exception != null || task.IsCanceled)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                    ConcreteBindingContext.IsBusy = false;
                });
            }
            else
            {
                var gaugeItems = new System.Collections.Generic.List<GaugeItem>();

                var weightedPoints = new System.Collections.Generic.List<LiveChartsCore.Defaults.WeightedPoint>();

                var monthlyObjectivesProgressChartXAxe = new LiveChartsCore.SkiaSharpView.Axis
                {
                    LabelsRotation = -15,
                    Labels = new System.Collections.Generic.List<string>(),
                    ForceStepToMin = true,
                    MinStep = 1
                };

                var objectiveOverviews = new System.Collections.Generic.List<Models.View.ObjectiveOverviewViewModel>();

                foreach (var obj in task.Result)
                {
                    var projectionCount = 0;
                    var actionCount = 0;
                    var indicatorCount = 0;

                    var indicatorCompletitionLevels = new System.Collections.Generic.List<double>();

                    foreach (var proyection in obj.Proyections)
                    {
                        projectionCount++;

                        foreach (var action in proyection.Actions)
                        {
                            actionCount++;

                            var lastResults = await resultsAPIConnectClient.GetLastsByIndicators(action.Indicators);

                            foreach (var indicator in action.Indicators)
                            {
                                indicatorCount++;

                                var targetResult = lastResults.FirstOrDefault(_model => _model.IndicatorId == indicator.Id);

                                indicatorCompletitionLevels.Add((targetResult?.Amount ?? 0) / indicator.Amount);
                            }
                        }
                    }

                    var totality = 0d;

                    indicatorCompletitionLevels.ForEach(x => totality += x);

                    var title = $"Obj. {obj.Index}";
                    var value = totality == 0 ? 0d : totality / indicatorCompletitionLevels.Count * 100;

                    monthlyObjectivesProgressChartXAxe.Labels.Add(title);

                    gaugeItems.Add(new GaugeItem(value, series =>
                    {
                        series.Name = title;
                        series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Start;
                        series.DataLabelsFormatter = point => $"{point.Context.Series.Name} - {point.Coordinate.PrimaryValue:F2}%";
                        series.InnerRadius = 24;
                        series.RelativeOuterRadius = 4;
                        series.RelativeInnerRadius = 4;
                    }));

                    objectiveOverviews.Add(new Models.View.ObjectiveOverviewViewModel
                    {
                        Index = obj.Index,
                        Title = title,
                        ProyectionCount = projectionCount,
                        ActionCount = actionCount,
                        IndicatorCount = indicatorCount,
                        ProgressChart = new Models.View.ChartViewModel
                        {
                            Series = GaugeGenerator.BuildSolidGauge(new GaugeItem(value, series =>
                            {
                                series.MaxRadialColumnWidth = 50;
                                series.DataLabelsSize = 50;
                            })).ToArray()
                        },
                        ProgressGlyph = glyphs[randomizer.Next(0, 4)]
                    });

                    for (int j = 0; j < 12; j++)
                    {
                        weightedPoints.Add(new LiveChartsCore.Defaults.WeightedPoint(obj.Index, j, randomizer.NextDouble() * 100));
                    }
                }

                gaugeItems.Add(new GaugeItem(GaugeItem.Background, series =>
                {
                    series.InnerRadius = 20;
                }));

                var byObjectiveProyections = new System.Collections.Generic.List<int>();
                var byObjectiveActions = new System.Collections.Generic.List<int>();
                var byObjectiveIndicators = new System.Collections.Generic.List<int>();

                foreach (var item in objectiveOverviews)
                {
                    byObjectiveProyections.Add(item.ProyectionCount);
                    byObjectiveActions.Add(item.ActionCount);
                    byObjectiveIndicators.Add(item.IndicatorCount);
                }

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.ObjectiveOverviews.Clear();

                    foreach (var item in objectiveOverviews)
                    {
                        ConcreteBindingContext.ObjectiveOverviews.Add(item);
                    }

                    ConcreteBindingContext.GlobalObjectivesStatusChart.Series = GaugeGenerator.BuildSolidGauge(gaugeItems.ToArray()).ToArray();

                    ConcreteBindingContext.MonthlyObjectivesProgressChart.XAxes = [monthlyObjectivesProgressChartXAxe];
                    ConcreteBindingContext.MonthlyObjectivesProgressChart.Series =
                    [
                        new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint> { Values = weightedPoints.ToArray() }
                    ];

                    ConcreteBindingContext.ProyectionCount = 21;
                    ConcreteBindingContext.ActionCount = ConcreteBindingContext.ProyectionCount * 4;
                    ConcreteBindingContext.IndicatorCount = ConcreteBindingContext.ActionCount * 2;

                    var indexer = 0;

                    ConcreteBindingContext.ProyectionDistributionChart.Series = byObjectiveProyections.AsPieSeries((value, series) =>
                    {
                        series.Name = monthlyObjectivesProgressChartXAxe.Labels[indexer++ % monthlyObjectivesProgressChartXAxe.Labels.Count];
                        series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
                        series.DataLabelsSize = 12;
                        series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
                        series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
                    }).ToArray();

                    ConcreteBindingContext.ActionDistributionChart.Series = byObjectiveActions.AsPieSeries((value, series) =>
                    {
                        series.Name = monthlyObjectivesProgressChartXAxe.Labels[indexer++ % monthlyObjectivesProgressChartXAxe.Labels.Count];
                        series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
                        series.DataLabelsSize = 12;
                        series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
                        series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
                    }).ToArray();

                    ConcreteBindingContext.IndicatorDistributionChart.Series = byObjectiveIndicators.AsPieSeries((value, series) =>
                    {
                        series.Name = monthlyObjectivesProgressChartXAxe.Labels[indexer++ % monthlyObjectivesProgressChartXAxe.Labels.Count];
                        series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
                        series.DataLabelsSize = 12;
                        series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
                        series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
                    }).ToArray();

                    ConcreteBindingContext.IsBusy = false;
                });
            }
        });
    }
}