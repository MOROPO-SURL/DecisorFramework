using LiveChartsCore.ConditionalDraw;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class ServicingDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.ServicingDashboardPageModel>
{
    public ServicingDashboardPage() : base(new Models.Page.ServicingDashboardPageModel
    {
        CollectBalanceMontlyChart = new Models.View.ChartViewModel(),
        OrderDistributionChart = new Models.View.ChartViewModel(),
        OrderReceptionBalanceMontlyChart = new Models.View.ChartViewModel(),
        MostClientOrderBalanceChart = new Models.View.ChartViewModel()
    })
    {
        InitializeComponent();

        CollectBalanceMontlyCartesianChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        OrderReceptionBalanceMontlyChartCartesianChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        OrderDistributionChartPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        MostClientOrderBalanceChartCartesianChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
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

            var trainingServicesAPIConnectClient = new Servicing.Interop.API.Connect.Clients.TrainingServicesAPIConnectClient(httpClientHelperProvider);
            var sampleAnalysisServicesAPIConnectClient = new Servicing.Interop.API.Connect.Clients.SampleAnalysisServicesAPIConnectClient(httpClientHelperProvider);
            var groundIntegralStudyServicesAPIConnectClient = new Servicing.Interop.API.Connect.Clients.GroundIntegralStudyServicesAPIConnectClient(httpClientHelperProvider);
            var sampleKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.SampleKindsAPIConnectClient(httpClientHelperProvider);

            var trainingServiceCount = await trainingServicesAPIConnectClient.CountAsync();
            var sampleAnalysisServiceCount = await sampleAnalysisServicesAPIConnectClient.CountAsync();
            var groundIntegralStudyServiceCount = await groundIntegralStudyServicesAPIConnectClient.CountAsync();
            var sampleKindCount = await sampleKindsAPIConnectClient.CountAsync();

            var collectBalanceMontlys = new System.Collections.Generic.List<double>();
            var orderReception1BalanceMontlys = new System.Collections.Generic.List<double>();
            var orderReception2BalanceMontlys = new System.Collections.Generic.List<double>();
            var orderReception3BalanceMontlys = new System.Collections.Generic.List<double>();

            var paints = new System.Collections.Generic.List<SolidColorPaint>();

            var clientInfos = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string,int>>();

            for (int i = 0; i < 12; i++)
            {
                collectBalanceMontlys.Add(System.Random.Shared.Next(500000));

                if (i >= 6) continue;

                orderReception1BalanceMontlys.Add(System.Random.Shared.Next(500));
                orderReception2BalanceMontlys.Add(System.Random.Shared.Next(500));
                orderReception3BalanceMontlys.Add(System.Random.Shared.Next(500));

                paints.Add(new SolidColorPaint(LiveChartsCore.Themes.ColorPalletes.MaterialDesign500[i].AsSKColor()));

                clientInfos.Add(new System.Collections.Generic.KeyValuePair<string, int>($"Cliente {i + 1}", System.Random.Shared.Next(500)));
            }

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.TrainingServiceCount = trainingServiceCount;
                BindingContextPageModel.SampleAnalysisServiceCount = sampleAnalysisServiceCount;
                BindingContextPageModel.GroundIntegralStudyServiceCount = groundIntegralStudyServiceCount;
                BindingContextPageModel.SampleKindCount = sampleKindCount;

                BindingContextPageModel.IsCollectBalanceMontlyChartMock = true;
                BindingContextPageModel.CollectBalanceMontlyChart = new Models.View.ChartViewModel
                {
                    XAxes = new Axis[]
                    {
                        new()
                        {
                            Labels = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
                            ForceStepToMin = true,
                            MinStep = 1
                        }
                    },
                    YAxes = new Axis[]
                    {
                        new()
                        {
                            Labeler = LiveChartsCore.Labelers.Currency
                        }
                    },
                    Series = new[]
                    {
                        new LineSeries<double>
                        {
                            Values = collectBalanceMontlys.ToArray()
                        }
                    }
                };

                BindingContextPageModel.IsOrderDistributionChartMock = true;
                BindingContextPageModel.OrderDistributionChart.Series = new[]
                {
                    new PieSeries<int>
                    {
                        Values = new int[] { System.Random.Shared.Next(1, 500) },
                        Name = "Capacitación",
                        Stroke = null
                    },
                    new PieSeries<int>
                    {
                        Values = new int[] { System.Random.Shared.Next(1, 500) },
                        Name = "Proc. de Muestras",
                        Stroke = null
                    },
                    new PieSeries<int>
                    {
                        Values = new int[] { System.Random.Shared.Next(1, 500) },
                        Name = "Est. Int. de Suelo",
                        Stroke = null
                    }
                };

                BindingContextPageModel.IsOrderReceptionBalanceMontlyChartMock = true;
                BindingContextPageModel.OrderReceptionBalanceMontlyChart = new Models.View.ChartViewModel
                {
                    XAxes = new LiveChartsCore.SkiaSharpView.Axis[]
                    {
                        new() {
                            Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
                            LabelsRotation = 0,
                            ShowSeparatorLines = true,
                            SeparatorsPaint = new SolidColorPaint(new SkiaSharp.SKColor(200, 200, 200)),
                            SeparatorsAtCenter = false,
                            ForceStepToMin = true,
                            MinStep = 1
                        }
                    },
                    Series = new[]
                    {
                        new ColumnSeries<double>
                        {
                            Name = "Capacitación",
                            MaxBarWidth = 20,
                            Values = orderReception1BalanceMontlys.ToArray()
                        },
                        new ColumnSeries<double>
                        {
                            Name = "Proc. de Muestras",
                            MaxBarWidth = 20,
                            Values = orderReception2BalanceMontlys.ToArray()
                        },
                        new ColumnSeries<double>
                        {
                            Name = "Est. Int. de Suelo",
                            MaxBarWidth = 20,
                            Values = orderReception3BalanceMontlys.ToArray()
                        }
                    }
                };

                var mostClientOrderBalanceChartRowSerie = new RowSeries<System.Collections.Generic.KeyValuePair<string, int>>
                {
                    Values = clientInfos.OrderByDescending(item => item.Value).ToArray(),
                    DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(245, 245, 245)),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.End,
                    DataLabelsTranslate = new(-1, 0),
                    DataLabelsFormatter = point => $"{point.Model.Key} - {point.Coordinate.PrimaryValue}",
                    MaxBarWidth = 50,
                    Padding = 10
                }.OnPointMeasured(point =>
                {
                    if (point.Visual is null) return;

                    point.Visual.Fill = paints[point.Index];
                });

                BindingContextPageModel.IsMostClientOrderBalanceChartMock = true;
                BindingContextPageModel.MostClientOrderBalanceChart = new Models.View.ChartViewModel
                {
                    YAxes = new Axis[]
                    {
                        new() {
                            IsVisible = false
                        }
                    },
                    XAxes = new Axis[] 
                    {
                        new()
                        {
                            SeparatorsPaint = new SolidColorPaint(new SkiaSharp.SKColor(220, 220, 220))
                        }
                    },
                    Series = new[]
                    {
                        mostClientOrderBalanceChartRowSerie
                    }
                };

                BindingContextPageModel.IsBusy = false;
            });
        });
    }
}