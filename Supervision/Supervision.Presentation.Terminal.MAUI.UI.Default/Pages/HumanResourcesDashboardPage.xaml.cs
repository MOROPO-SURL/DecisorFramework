using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.UI.Default.Pages;

public partial class HumanResourcesDashboardPage : Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.HumanResourcesDashboardPageModel>
{
	public HumanResourcesDashboardPage() : base(new Models.Page.HumanResourcesDashboardPageModel())
    {
		InitializeComponent();

        BindingContextPageModel.Bind(StaffChange_Callback);
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

        StaffChange_Callback();
    }

    private void StaffChange_Callback()
    {
        BindingContextPageModel.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            await System.Threading.Tasks.Task.Delay(500);

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var vacantCount = 0;
            var ocupationCount = 0;

            if (BindingContextPageModel.Staff != null)
            {
                var ocupationsAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.OcupationsAPIConnectClient(httpClientHelperProvider);
                var workforcesAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.WorkforcesAPIConnectClient(httpClientHelperProvider);

                var workforce = await workforcesAPIConnectClient.GetAsync(BindingContextPageModel.Staff.MainWorkforce.Id);
                var ocupations = await ocupationsAPIConnectClient.FilterAsync(new HumanResources.Interop.API.Common.Models.Filter.OcupationFilterModel { StaffId = BindingContextPageModel.Staff.Id, WorkforceId = BindingContextPageModel.Staff.MainWorkforce.Id });

                foreach (var organizationalUnity in workforce.OrganizationalUnities)
                {
                    vacantCount += CountVacants(organizationalUnity);
                }

                ocupationCount = ocupations.Length;
            }

            var staffCompletitionPathMontlyValues = new System.Collections.Generic.List<double>();
            var staffCompletitionByWorkPositionKindValues = new System.Collections.Generic.List<double>();
            var staffCompositionByAgeValues = new System.Collections.Generic.Dictionary<string, int>
            {
                { "menores de 20 años", System.Random.Shared.Next(10) },
                { "entre 20 y 29 años", System.Random.Shared.Next(20) },
                { "entre 30 de 39 años", System.Random.Shared.Next(30) },
                { "entre 40 de 49 años", System.Random.Shared.Next(20) },
                { "entre 50 de 59 años", System.Random.Shared.Next(10) },
                { "mayores de 60 años", System.Random.Shared.Next(5) }
            };

            // TODO Retrive trhow StaffStatsSnapshut
            for (int i = 0; i < 12; i++)
            {
                staffCompletitionPathMontlyValues.Add(System.Random.Shared.Next(100));

                if (i > 4) continue;

                staffCompletitionByWorkPositionKindValues.Add(System.Random.Shared.Next(100));
            }

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.IsStaffCompletitionGlobalPieChartMock = vacantCount < 1;

                BindingContextPageModel.StaffCompletitionGlobalPieChart = new Models.View.ChartViewModel
                {
                    Series = LiveChartsCore.SkiaSharpView.Extensions.GaugeGenerator.BuildSolidGauge(
                        new LiveChartsCore.SkiaSharpView.Extensions.GaugeItem(BindingContextPageModel.IsStaffCompletitionGlobalPieChartMock ? System.Convert.ToDouble(System.Random.Shared.Next(20, 80)) : System.Convert.ToDouble(vacantCount) / System.Convert.ToDouble(ocupationCount) * 100d, series =>
                        {
                            series.Fill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.SkyBlue);
                            series.DataLabelsSize = 50;
                            series.DataLabelsPaint = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.SkyBlue);
                            series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.ChartCenter;
                            series.InnerRadius = 75;
                        }),
                        new LiveChartsCore.SkiaSharpView.Extensions.GaugeItem(LiveChartsCore.SkiaSharpView.Extensions.GaugeItem.Background, series =>
                        {
                            series.InnerRadius = 75;
                            series.Fill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.DimGray);
                        })).ToArray()
                };

                BindingContextPageModel.IsStaffCompletitionByWorkPositionKindCartesianChartMock = true;
                BindingContextPageModel.StaffCompletitionByWorkPositionKindCartesianChart = new Models.View.ChartViewModel
                {
                    XAxes = new Axis[]
                    {
                        new()
                        {
                            Labeler = value =>  $"{value:F2}%",
                            MinLimit = 0,
                            MaxLimit = 100
                        }
                    },
                    YAxes = new Axis[] 
                    {
                        new()
                        {
                            Labels = ["Cuadros", "Administrativos", "Técnicos", "Trab. de Servicio", "Operarios"],
                            ForceStepToMin = true,
                            MinStep = 1
                        }
                    },
                    Series = new[] 
                    {
                        new RowSeries<double>
                        {
                            Values = new double[] { 100d, 100d, 100d, 100d, 100d },
                            IsHoverable = false,
                            Fill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.DimGray),
                            IgnoresBarPosition = true
                        },
                        new RowSeries<double>
                        {
                            Values = staffCompletitionByWorkPositionKindValues.ToArray(),
                            IgnoresBarPosition = true,
                            DataLabelsFormatter = point => $"{point.Model:F2}%"
                        }
                    }
                };

                BindingContextPageModel.IsStaffCompletitionPathMontlyCartesianChartMock = true;
                BindingContextPageModel.StaffCompletitionPathMontlyCartesianChart = new Models.View.ChartViewModel
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
                            Labeler = value =>  $"{value:F2}%"
                        }
                    },
                    Series = new[]
                    {
                        new LineSeries<double>
                        {
                            Values = staffCompletitionPathMontlyValues.ToArray(),
                            DataLabelsFormatter = point => $"{point.Model:F2}%"
                        }
                    }
                };

                BindingContextPageModel.IsStaffCompositionByAgePieChartMock = true;

                BindingContextPageModel.StaffCompositionByAgePieChart = new Models.View.ChartViewModel
                {
                    Series = staffCompositionByAgeValues.Select(item => new PieSeries<int>
                    {
                        Values = new int[] { item.Value },
                        Name = item.Key,
                        Stroke = null
                    }).ToArray()
                };

                BindingContextPageModel.IsStaffCompositionBySexPieChartMock = true;

                BindingContextPageModel.StaffCompositionBySexPieChart = new Models.View.ChartViewModel
                {
                    Series = new[]
                    {
                        new PieSeries<int>
                        {
                            Values = new int[] { System.Random.Shared.Next(60) },
                            Name = "Masculino",
                            Stroke = null
                        },
                        new PieSeries<int>
                        {
                            Values = new int[] { System.Random.Shared.Next(60) },
                            Name = "Femenino",
                            Stroke = null
                        }
                    }
                };

                BindingContextPageModel.IsStaffCompositionBySkinKindPieChartMock = true;

                BindingContextPageModel.StaffCompositionBySkinKindPieChart = new Models.View.ChartViewModel
                {
                    Series = new[]
                    {
                        new PieSeries<int>
                        {
                            Values = new int[] { System.Random.Shared.Next(30) },
                            Name = "Blanca",
                            Stroke = null
                        },
                        new PieSeries<int>
                        {
                            Values = new int[] { System.Random.Shared.Next(30) },
                            Name = "Negra",
                            Stroke = null
                        },
                        new PieSeries<int>
                        {
                            Values = new int[] { System.Random.Shared.Next(30) },
                            Name = "Mestiza",
                            Stroke = null
                        }
                    }
                };

                BindingContextPageModel.IsBusy = false;
            });
        }).ContinueWith(task =>
        {
            if (!task.IsCanceled && task.Exception == null) return;

            Dispatcher.Dispatch(() => Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this));
        });
    }

    private int CountVacants(HumanResources.Interop.API.Common.Models.Display.WorkforceOrganizationalUnityDisplayModel model)
    {
        var result = 1 + model.Vacants.Length;

        foreach (var child in model.Children)
        {
            result += CountVacants(child);
        }

        return result;
    }
}