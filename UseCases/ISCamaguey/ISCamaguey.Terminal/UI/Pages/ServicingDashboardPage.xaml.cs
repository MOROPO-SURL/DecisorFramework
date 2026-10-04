using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Connect.Clients;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class ServicingDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.ServicingDashboardPageModel>
{
    private readonly IDispatcherTimer carouselTimer;

    private bool scrollToUp = true;

    public ServicingDashboardPage() : base(new Models.Page.ServicingDashboardPageModel
    {
        Images = [
            ImageSource.FromFile("servicing_showcase_1.jpg"),
            ImageSource.FromFile("servicing_showcase_2.jpg"),
            ImageSource.FromFile("servicing_showcase_3.jpg"),
            ImageSource.FromFile("servicing_showcase_4.jpg"),
            ImageSource.FromFile("servicing_showcase_5.jpg")
        ],
        //CollectBalanceMontlyChart = new Models.View.ChartViewModel(),
        //OrderDistributionChart = new Models.View.ChartViewModel(),
        //OrderReceptionBalanceMontlyChart = new Models.View.ChartViewModel(),
        //MostClientOrderBalanceChart = new Models.View.ChartViewModel()
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

        //CollectBalanceMontlyCartesianChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        //OrderReceptionBalanceMontlyChartCartesianChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        //OrderDistributionChartPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        //MostClientOrderBalanceChartCartesianChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
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

    private void Refresh()
    {
        if (BindingContextPageModel.IsBusy) return;

        BindingContextPageModel.IsBusy = true;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        TrainingServicesAPIConnectClient trainingServicesAPIConnectClient = new(httpClientHelperProvider);
        SampleAnalysisServicesAPIConnectClient sampleAnalysisServicesAPIConnectClient = new(httpClientHelperProvider);
        GroundIntegralStudyServicesAPIConnectClient groundIntegralStudyServicesAPIConnectClient = new(httpClientHelperProvider);
        SampleKindsAPIConnectClient sampleKindsAPIConnectClient = new(httpClientHelperProvider);
        LegalClientGroundIntegralStudyServiceOrdersAPIConnectClient legalClientGroundIntegralStudyServiceOrdersAPIConnectClient = new(httpClientHelperProvider);
        LegalClientGroundIntegralStudyServiceExecutionsAPIConnectClient legalClientGroundIntegralStudyServiceExecutionsAPIConnectClient = new(httpClientHelperProvider);
        LegalClientSampleAnalysisServiceOrdersAPIConnectClient legalClientSampleAnalysisServiceOrdersAPIConnectClient = new(httpClientHelperProvider);
        LegalClientSampleAnalysisServiceExecutionsAPIConnectClient legalClientSampleAnalysisServiceExecutionsAPIConnectClient = new(httpClientHelperProvider);
        LegalClientTrainingServiceOrdersAPIConnectClient legalClientTrainingServiceOrdersAPIConnectClient = new(httpClientHelperProvider);
        LegalClientTrainingServiceExecutionsAPIConnectClient legalClientTrainingServiceExecutionsAPIConnectClient = new(httpClientHelperProvider);
        NaturalClientGroundIntegralStudyServiceOrdersAPIConnectClient naturalClientGroundIntegralStudyServiceOrdersAPIConnectClient = new(httpClientHelperProvider);
        NaturalClientGroundIntegralStudyServiceExecutionsAPIConnectClient naturalClientGroundIntegralStudyServiceExecutionsAPIConnectClient = new(httpClientHelperProvider);
        NaturalClientSampleAnalysisServiceOrdersAPIConnectClient naturalClientSampleAnalysisServiceOrdersAPIConnectClient = new(httpClientHelperProvider);
        NaturalClientSampleAnalysisServiceExecutionsAPIConnectClient naturalClientSampleAnalysisServiceExecutionsAPIConnectClient = new(httpClientHelperProvider);
        NaturalClientTrainingServiceOrdersAPIConnectClient naturalClientTrainingServiceOrdersAPIConnectClient = new(httpClientHelperProvider);
        NaturalClientTrainingServiceExecutionsAPIConnectClient naturalClientTrainingServiceExecutionsAPIConnectClient = new(httpClientHelperProvider);
        LegalClientsAPIConnectClient legalClientsAPIConnectClient = new(httpClientHelperProvider);
        NaturalClientsAPIConnectClient naturalClientsAPIConnectClient = new(httpClientHelperProvider);
        LegalClientServicingContractsAPIConnectClient legalClientServicingContractsAPIConnectClient = new(httpClientHelperProvider);
        NaturalClientServicingContractsAPIConnectClient naturalClientServicingContractsAPIConnectClient = new(httpClientHelperProvider);

        var trainingServiceCountTask = trainingServicesAPIConnectClient.CountAsync();
        var sampleAnalysisServiceCountTask = sampleAnalysisServicesAPIConnectClient.CountAsync();
        var groundIntegralStudyServiceCountTask = groundIntegralStudyServicesAPIConnectClient.CountAsync();
        var sampleKindCountTask = sampleKindsAPIConnectClient.CountAsync();
        var legalClientGroundIntegralStudyServiceOrderCountTask = legalClientGroundIntegralStudyServiceOrdersAPIConnectClient.CountAsync();
        var legalClientGroundIntegralStudyServiceExecutionCountTask = legalClientGroundIntegralStudyServiceExecutionsAPIConnectClient.CountAsync();
        var legalClientSampleAnalysisServiceOrderCountTask = legalClientSampleAnalysisServiceOrdersAPIConnectClient.CountAsync();
        var legalClientSampleAnalysisServiceExecutionCountTask = legalClientSampleAnalysisServiceExecutionsAPIConnectClient.CountAsync();
        var legalClientTrainingServiceOrderCountTask = legalClientTrainingServiceOrdersAPIConnectClient.CountAsync();
        var legalClientTrainingServiceExecutionCountTask = legalClientTrainingServiceExecutionsAPIConnectClient.CountAsync();
        var naturalClientGroundIntegralStudyServiceOrderCountTask = naturalClientGroundIntegralStudyServiceOrdersAPIConnectClient.CountAsync();
        var naturalClientGroundIntegralStudyServiceExecutionCountTask = naturalClientGroundIntegralStudyServiceExecutionsAPIConnectClient.CountAsync();
        var naturalClientSampleAnalysisServiceOrderCountTask = naturalClientSampleAnalysisServiceOrdersAPIConnectClient.CountAsync();
        var naturalClientSampleAnalysisServiceExecutionCountTask = naturalClientSampleAnalysisServiceExecutionsAPIConnectClient.CountAsync();
        var naturalClientTrainingServiceOrderCountTask = naturalClientTrainingServiceOrdersAPIConnectClient.CountAsync();
        var naturalClientTrainingServiceExecutionCountTask = naturalClientTrainingServiceExecutionsAPIConnectClient.CountAsync();
        var legalClientCountTask = legalClientsAPIConnectClient.CountAsync();
        var naturalClientCountTask = naturalClientsAPIConnectClient.CountAsync();
        var legalClientServicingContractCountTask = legalClientServicingContractsAPIConnectClient.CountAsync();
        var naturalClientServicingContractCountTask = naturalClientServicingContractsAPIConnectClient.CountAsync();

        System.Threading.Tasks.Task.WhenAll(
            trainingServiceCountTask,
            sampleAnalysisServiceCountTask,
            groundIntegralStudyServiceCountTask,
            sampleKindCountTask,
            legalClientGroundIntegralStudyServiceOrderCountTask,
            legalClientGroundIntegralStudyServiceExecutionCountTask,
            legalClientSampleAnalysisServiceOrderCountTask,
            legalClientSampleAnalysisServiceExecutionCountTask,
            legalClientTrainingServiceOrderCountTask,
            legalClientTrainingServiceExecutionCountTask,
            naturalClientGroundIntegralStudyServiceOrderCountTask,
            naturalClientGroundIntegralStudyServiceExecutionCountTask,
            naturalClientSampleAnalysisServiceOrderCountTask,
            naturalClientSampleAnalysisServiceExecutionCountTask,
            naturalClientTrainingServiceOrderCountTask,
            naturalClientTrainingServiceExecutionCountTask,
            legalClientCountTask,
            naturalClientCountTask,
            legalClientServicingContractCountTask,
            naturalClientServicingContractCountTask).ContinueWith(task =>
        {
            //var collectBalanceMontlys = new System.Collections.Generic.List<double>();
            //var orderReception1BalanceMontlys = new System.Collections.Generic.List<double>();
            //var orderReception2BalanceMontlys = new System.Collections.Generic.List<double>();
            //var orderReception3BalanceMontlys = new System.Collections.Generic.List<double>();

            //var paints = new System.Collections.Generic.List<SolidColorPaint>();

            //var clientInfos = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string,int>>();

            //for (int i = 0; i < 12; i++)
            //{
            //    collectBalanceMontlys.Add(System.Random.Shared.Next(500000));

            //    if (i >= 6) continue;

            //    orderReception1BalanceMontlys.Add(System.Random.Shared.Next(500));
            //    orderReception2BalanceMontlys.Add(System.Random.Shared.Next(500));
            //    orderReception3BalanceMontlys.Add(System.Random.Shared.Next(500));

            //    paints.Add(new SolidColorPaint(LiveChartsCore.Themes.ColorPalletes.MaterialDesign500[i].AsSKColor()));

            //    clientInfos.Add(new System.Collections.Generic.KeyValuePair<string, int>($"Cliente {i + 1}", System.Random.Shared.Next(500)));
            //}

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.TrainingServiceCount = trainingServiceCountTask.Result;
                BindingContextPageModel.SampleAnalysisServiceCount = sampleAnalysisServiceCountTask.Result;
                BindingContextPageModel.GroundIntegralStudyServiceCount = groundIntegralStudyServiceCountTask.Result;
                BindingContextPageModel.SampleKindCount = sampleKindCountTask.Result;
                BindingContextPageModel.ServiceOrderCount =
                    legalClientGroundIntegralStudyServiceOrderCountTask.Result +
                    legalClientSampleAnalysisServiceOrderCountTask.Result +
                    legalClientTrainingServiceOrderCountTask.Result +
                    naturalClientGroundIntegralStudyServiceOrderCountTask.Result +
                    naturalClientSampleAnalysisServiceOrderCountTask.Result +
                    naturalClientTrainingServiceOrderCountTask.Result;
                BindingContextPageModel.ServiceExecutionCount =
                    legalClientGroundIntegralStudyServiceExecutionCountTask.Result +
                    legalClientSampleAnalysisServiceExecutionCountTask.Result +
                    legalClientTrainingServiceExecutionCountTask.Result +
                    naturalClientGroundIntegralStudyServiceExecutionCountTask.Result +
                    naturalClientSampleAnalysisServiceExecutionCountTask.Result +
                    naturalClientTrainingServiceExecutionCountTask.Result;
                BindingContextPageModel.ClientCount = legalClientCountTask.Result + naturalClientCountTask.Result;
                BindingContextPageModel.ContractCount = legalClientServicingContractCountTask.Result + naturalClientServicingContractCountTask.Result;

                BindingContextPageModel.HasAnySampleKind = sampleKindCountTask.Result > 0;

                BindingContextPageModel.IsModuleReady = BindingContextPageModel.HasAnySampleKind;

                //BindingContextPageModel.IsCollectBalanceMontlyChartMock = true;
                //BindingContextPageModel.CollectBalanceMontlyChart = new Models.View.ChartViewModel
                //{
                //    XAxes = new Axis[]
                //    {
                //        new()
                //        {
                //            Labels = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
                //            ForceStepToMin = true,
                //            MinStep = 1
                //        }
                //    },
                //    YAxes = new Axis[]
                //    {
                //        new()
                //        {
                //            Labeler = LiveChartsCore.Labelers.Currency
                //        }
                //    },
                //    Series = new[]
                //    {
                //        new LineSeries<double>
                //        {
                //            Values = collectBalanceMontlys.ToArray()
                //        }
                //    }
                //};

                //BindingContextPageModel.IsOrderDistributionChartMock = true;
                //BindingContextPageModel.OrderDistributionChart.Series = new[]
                //{
                //    new PieSeries<int>
                //    {
                //        Values = new int[] { System.Random.Shared.Next(1, 500) },
                //        Name = "Capacitación",
                //        Stroke = null
                //    },
                //    new PieSeries<int>
                //    {
                //        Values = new int[] { System.Random.Shared.Next(1, 500) },
                //        Name = "Proc. de Muestras",
                //        Stroke = null
                //    },
                //    new PieSeries<int>
                //    {
                //        Values = new int[] { System.Random.Shared.Next(1, 500) },
                //        Name = "Est. Int. de Suelo",
                //        Stroke = null
                //    }
                //};

                //BindingContextPageModel.IsOrderReceptionBalanceMontlyChartMock = true;
                //BindingContextPageModel.OrderReceptionBalanceMontlyChart = new Models.View.ChartViewModel
                //{
                //    XAxes = new LiveChartsCore.SkiaSharpView.Axis[]
                //    {
                //        new() {
                //            Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
                //            LabelsRotation = 0,
                //            ShowSeparatorLines = true,
                //            SeparatorsPaint = new SolidColorPaint(new SkiaSharp.SKColor(200, 200, 200)),
                //            SeparatorsAtCenter = false,
                //            ForceStepToMin = true,
                //            MinStep = 1
                //        }
                //    },
                //    Series = new[]
                //    {
                //        new ColumnSeries<double>
                //        {
                //            Name = "Capacitación",
                //            MaxBarWidth = 20,
                //            Values = orderReception1BalanceMontlys.ToArray()
                //        },
                //        new ColumnSeries<double>
                //        {
                //            Name = "Proc. de Muestras",
                //            MaxBarWidth = 20,
                //            Values = orderReception2BalanceMontlys.ToArray()
                //        },
                //        new ColumnSeries<double>
                //        {
                //            Name = "Est. Int. de Suelo",
                //            MaxBarWidth = 20,
                //            Values = orderReception3BalanceMontlys.ToArray()
                //        }
                //    }
                //};

                //var mostClientOrderBalanceChartRowSerie = new RowSeries<System.Collections.Generic.KeyValuePair<string, int>>
                //{
                //    Values = clientInfos.OrderByDescending(item => item.Value).ToArray(),
                //    DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(245, 245, 245)),
                //    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.End,
                //    DataLabelsTranslate = new(-1, 0),
                //    DataLabelsFormatter = point => $"{point.Model.Key} - {point.Coordinate.PrimaryValue}",
                //    MaxBarWidth = 50,
                //    Padding = 10
                //}.OnPointMeasured(point =>
                //{
                //    if (point.Visual is null) return;

                //    point.Visual.Fill = paints[point.Index];
                //});

                //BindingContextPageModel.IsMostClientOrderBalanceChartMock = true;
                //BindingContextPageModel.MostClientOrderBalanceChart = new Models.View.ChartViewModel
                //{
                //    YAxes = new Axis[]
                //    {
                //        new() {
                //            IsVisible = false
                //        }
                //    },
                //    XAxes = new Axis[] 
                //    {
                //        new()
                //        {
                //            SeparatorsPaint = new SolidColorPaint(new SkiaSharp.SKColor(220, 220, 220))
                //        }
                //    },
                //    Series = new[]
                //    {
                //        mostClientOrderBalanceChartRowSerie
                //    }
                //};

                BindingContextPageModel.IsBusy = false;
            });
        });
    }
}