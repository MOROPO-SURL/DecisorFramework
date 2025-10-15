using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
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
                XAxes = [
                    new LiveChartsCore.SkiaSharpView.Axis
                    {
                        LabelsRotation = -15,
                        Labels = ["Obj. 1", "Obj. 2", "Obj. 3", "Obj. 4", "Obj. 5", "Obj. 6", "Obj. 7", "Obj. 8", "Obj. 9", "Obj. 10"],
                        ForceStepToMin = true,
                        MinStep = 1
                    }
                ],
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

        //ConcreteBindingContext.IsBusy = true;

        var glyphs = new char[] { '\uF05D', '\uF05C', '\uF045', '\uF042', '\uF84E' };

        var gaugeItems = new System.Collections.Generic.List<GaugeItem>();

        var weightedPoints = new System.Collections.Generic.List<LiveChartsCore.Defaults.WeightedPoint>();

        var randomizer = new System.Random();

        for (int i = 0; i < 10; i++)
        {
            var title = $"Obj. {i + 1}";
            var value = randomizer.NextDouble() * 100;

            gaugeItems.Add(new GaugeItem(value, series =>
            {
                series.Name = title;
                //series.DataLabelsSize = 12;
                series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Start;
                series.DataLabelsFormatter = point => $"{point.Context.Series.Name} - {point.Coordinate.PrimaryValue:F0}%";
                series.InnerRadius = 24;
                series.RelativeOuterRadius = 4;
                series.RelativeInnerRadius = 4;
            }));

            ConcreteBindingContext.ObjectiveOverviews.Add(new Models.View.ObjectiveOverviewViewModel
            {
                Index = i + 1,
                Title = title,
                ProyectionCount = i + 1,
                ActionCount = (i + 1) * 4,
                IndicatorCount = (i + 1) * 4 * 2,
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
                weightedPoints.Add(new LiveChartsCore.Defaults.WeightedPoint(i, j, randomizer.NextDouble() * 100));
            }
        }

        gaugeItems.Add(new GaugeItem(GaugeItem.Background, series =>
        {
            series.InnerRadius = 20;
        }));

        ConcreteBindingContext.GlobalObjectivesStatusChart.Series = GaugeGenerator.BuildSolidGauge(gaugeItems.ToArray()).ToArray();

        ConcreteBindingContext.MonthlyObjectivesProgressChart.Series = new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint>[]
        {
            new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint> { Values = weightedPoints.ToArray() }
        };

        ConcreteBindingContext.ProyectionCount = 21;
        ConcreteBindingContext.ActionCount = ConcreteBindingContext.ProyectionCount * 4;
        ConcreteBindingContext.IndicatorCount = ConcreteBindingContext.ActionCount * 2;

        var indexer = 0;

        var objectiveLabels = new string[] { "Obj. 1", "Obj. 2", "Obj. 3", "Obj. 4", "Obj. 5", "Obj. 6", "Obj. 7", "Obj. 8", "Obj. 9", "Obj. 10" };

        ConcreteBindingContext.ProyectionDistributionChart.Series = new[] { 8, 6, 5, 3, 3, 4, 7, 2, 10, 12 }.AsPieSeries((value, series) =>
        {
            series.Name = objectiveLabels[indexer++ % objectiveLabels.Length];
            series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
            series.DataLabelsSize = 12;
            series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
            series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
        }).ToArray();

        ConcreteBindingContext.ActionDistributionChart.Series = new[] { 18, 26, 5, 13, 18, 21, 11, 12, 10, 24 }.AsPieSeries((value, series) =>
        {
            series.Name = objectiveLabels[indexer++ % objectiveLabels.Length];
            series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
            series.DataLabelsSize = 12;
            series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
            series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
        }).ToArray();

        ConcreteBindingContext.IndicatorDistributionChart.Series = new[] { 24, 26, 8, 13, 19, 27, 12, 12, 20, 24 }.AsPieSeries((value, series) =>
        {
            series.Name = objectiveLabels[indexer++ % objectiveLabels.Length];
            series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
            series.DataLabelsSize = 12;
            series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
            series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
        }).ToArray();
    }
}