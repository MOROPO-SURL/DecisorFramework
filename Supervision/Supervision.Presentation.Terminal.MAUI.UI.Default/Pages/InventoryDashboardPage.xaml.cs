using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.UI.Default.Pages;

public partial class InventoryDashboardPage : Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.InventoryDashboardPageModel>
{
    public InventoryDashboardPage() : base(new Models.Page.InventoryDashboardPageModel
    {
        ReceptionsChart = new Models.View.ChartViewModel
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
        DeparturesChart = new Models.View.ChartViewModel
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
        WarehoursesChart = new Models.View.ChartViewModel(),
        RootCategoriesChart = new Models.View.ChartViewModel(),
        ProductsChart = new Models.View.ChartViewModel
        {
            XAxes = new LiveChartsCore.SkiaSharpView.Axis[]
            {
                new()
                {
                    LabelsRotation = -15,
                    ForceStepToMin = true,
                    MinStep = 1,
                    Labels = ["Mojarra", "Filete de Mojarra", "Picadillo de Cerdo", "Sal Fina", "Azucar Blanca", "Azucar Parda", "Nylon para Empaque", "Diesel", "Aceite de Motor", "Etiquetas", "Papel Formato A4", "Papel Formato Carta"]
                }
            }
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

            var warehousesAPIConnectClient = new Inventory.Interop.API.Connect.Clients.WarehousesAPIConnectClient(httpClientHelperProvider);
            var productsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ProductsAPIConnectClient(httpClientHelperProvider);
            var categoriesAPIConnectClient = new Inventory.Interop.API.Connect.Clients.CategoriesAPIConnectClient(httpClientHelperProvider);

            var warehouseCount = await warehousesAPIConnectClient.CountAsync();
            var productCount = await productsAPIConnectClient.CountAsync();
            var categoryCount = await categoriesAPIConnectClient.CountAsync();

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.WarehouseCount = warehouseCount;
                BindingContextPageModel.ProductDefinitionCount = productCount;
                BindingContextPageModel.CategoryCount = categoryCount;
                BindingContextPageModel.ReceptionsChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.StepLineSeries<double>
                    {
                        Values = new double[] { 10, 25, 21, 6, 18, 30 },
                        Fill = null
                    }
                };
                BindingContextPageModel.DeparturesChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.StepLineSeries<double>
                    {
                        Values = new double[] { 18, 15, 12, 2, 2, 12 },
                        Fill = null
                    }
                };
                BindingContextPageModel.WarehoursesChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 200 },
                        Name = "Central",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 50 },
                        Name = "Cámara Fría OBE",
                        Stroke = null
                    }
                };
                BindingContextPageModel.RootCategoriesChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 180 },
                        MaxRadialColumnWidth = 80,
                        Name = "Cárnicos Frescos",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 120 },
                        MaxRadialColumnWidth = 80,
                        Name = "Pescado Fresco",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 80 },
                        MaxRadialColumnWidth = 80,
                        Name = "Insumos de Empaque",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 30 },
                        MaxRadialColumnWidth = 80,
                        Name = "Portadores Energéticos",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { 70 },
                        MaxRadialColumnWidth = 80,
                        Name = "Material de Oficina",
                        Stroke = null
                    }
                };
                BindingContextPageModel.ProductsChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    {
                        Values = new decimal[] { 80, 100, 30, 96, 0, 180, 60, 10, 50, 160, 30, 5 },
                        Stroke = null,
                        Name = "Central"
                    },
                    new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    {
                        Values = new decimal[] { 300, 20, 70, 12, 120, 60, 90, 180, 20, 0, 30, 270 },
                        Stroke = null,
                        Name = "Cámara Fría OBE"
                    },
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //},
                    //new LiveChartsCore.SkiaSharpView.StackedColumnSeries<decimal>
                    //{
                    //    Values = new decimal[] { 300, 20 },
                    //    Stroke = null
                    //}
                };
                BindingContextPageModel.IsBusy = false;
            });
        });
    }
}