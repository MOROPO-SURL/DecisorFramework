using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.UI.Default.Pages;

public partial class PurchasingDashboardPage : Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.PurchasingDashboardPageModel>
{
	public PurchasingDashboardPage() : base(new Models.Page.PurchasingDashboardPageModel
    {
        PurchaseLastMonthsCountAreaChart = new Models.View.ChartViewModel
        {
            XAxes = new LiveChartsCore.SkiaSharpView.Axis[]
            {
                new() {
                    Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
                    //LabelsRotation = 0,
                    //SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
                    //SeparatorsAtCenter = false,
                    //TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
                    //TicksAtCenter = true,
                    //// By default the axis tries to optimize the number of 
                    //// labels to fit the available space, 
                    //// when you need to force the axis to show all the labels then you must: 
                    ForceStepToMin = true,
                    MinStep = 1
                }
            }
        },
        PurchaseZonePurchasesDoughnutChart = new Models.View.ChartViewModel(),
        ProviderPurchasingAmountHeatChart = new Models.View.ChartViewModel
        {
            XAxes = [
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labels = ["PescaSur-LAY", "PescaCAM", "ABAPESCA", "Rogelio Samora"],
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

        BindingContextPageModel.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var purchasePlansAPIConnectClient = new Purchasing.Interop.API.Connect.Clients.PurchasePlansAPIConnectClient(httpClientHelperProvider);
            var purchasesAPIConnectClient = new Purchasing.Interop.API.Connect.Clients.PurchasesAPIConnectClient(httpClientHelperProvider);
            var purchaseZonesAPIConnectClient = new Purchasing.Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(httpClientHelperProvider);
            var legalProvidersAPIConnectClient = new Purchasing.Interop.API.Connect.Clients.LegalProvidersAPIConnectClient(httpClientHelperProvider);
            var naturalProvidersAPIConnectClient = new Purchasing.Interop.API.Connect.Clients.NaturalProvidersAPIConnectClient(httpClientHelperProvider);

            var purchaseZoneCount = await purchaseZonesAPIConnectClient.CountAsync();
            var purchasePlanCount = await purchasePlansAPIConnectClient.CountAsync();
            var purchaseCount = await purchasesAPIConnectClient.CountAsync();
            var legalProviderCount = await legalProvidersAPIConnectClient.CountAsync();
            var naturalProviderCount = await naturalProvidersAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.PurchaseZoneCount = purchaseZoneCount;
                BindingContextPageModel.PurchasePlanCount = purchasePlanCount;
                BindingContextPageModel.PurchaseCount = purchaseCount;
                BindingContextPageModel.ProviderCount = legalProviderCount + naturalProviderCount;
                BindingContextPageModel.PurchaseLastMonthsCountAreaChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.LineSeries<double>
                    {
                        Values = new double[] { 10, 15, 12, 6, 2, 9 },
                        // Set he Fill property to build an area series
                        // by default the series has a fill color based on your app theme

                        //Stroke = null,
                        //GeometryFill = null,
                        //GeometryStroke = null
                    }
                };
                BindingContextPageModel.PurchaseZonePurchasesDoughnutChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 200 },
                        Name = "Santa Cruz del Sur",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 50 },
                        Name = "Camalote",
                        Stroke = null
                    }
                };
                BindingContextPageModel.ProviderPurchasingAmountHeatChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint>
                    {
                        Values = new LiveChartsCore.Defaults.WeightedPoint[] {
                            // Charles
                            new(0, 0, 150), // Jan
                            new(0, 1, 123), // Feb
                            new(0, 2, 310), // Mar
                            new(0, 3, 225), // Apr
                            new(0, 4, 473), // May
                            new(0, 5, 373), // Jun

                            // Richard
                            new(1, 0, 432), // Jan
                            new(1, 1, 312), // Feb
                            new(1, 2, 135), // Mar
                            new(1, 3, 78), // Apr
                            new(1, 4, 124), // May
                            new(1, 5, 423), // Jun

                            // Ana
                            new(2, 0, 543), // Jan
                            new(2, 1, 134), // Feb
                            new(2, 2, 524), // Mar
                            new(2, 3, 315), // Apr
                            new(2, 4, 145), // May
                            new(2, 5, 80), // Jun

                            // Mari
                            new(3, 0, 90), // Jan
                            new(3, 1, 123), // Feb
                            new(3, 2, 70), // Mar
                            new(3, 3, 123), // Apr
                            new(3, 4, 432), // May
                            new(3, 5, 142), // Jun
                        }
                    }
                };
                BindingContextPageModel.IsBusy = false;
            });
        });
    }
}