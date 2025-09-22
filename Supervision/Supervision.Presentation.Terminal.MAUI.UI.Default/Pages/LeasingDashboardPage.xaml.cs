using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System.Linq;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.UI.Default.Pages;

public partial class LeasingDashboardPage : Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.LeasingDashboardPageModel>
{
    public LeasingDashboardPage() : base(new Models.Page.LeasingDashboardPageModel
    {
        VehicleAssignmentPieChart = new Models.View.ChartViewModel(),
        VehicleLeasingPieChart = new Models.View.ChartViewModel(),
        PropertySpaceAssignmentPieChart = new Models.View.ChartViewModel(),
        PropertyLeasingPieChart = new Models.View.ChartViewModel()
    })
    {
        InitializeComponent();

        VehicleAssignmentPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        VehicleLeasingPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        PropertySpaceAssignmentPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        PropertyLeasingPieChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.PieChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
        ClientPaymentPertinenceHeatChart.SetAppTheme<LiveChartsCore.Drawing.IPaint<LiveChartsCore.SkiaSharpView.Drawing.SkiaSharpDrawingContext>>(LiveChartsCore.SkiaSharpView.Maui.CartesianChart.LegendTextPaintProperty, new SolidColorPaint(SkiaSharp.SKColors.Black), new SolidColorPaint(SkiaSharp.SKColors.White));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContextPageModel.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var propertiesAPIConnectClient = new Domain.Interop.API.Connect.Clients.PropertiesAPIConnectClient(httpClientHelperProvider);
            var vehiclesAPIConnectClient = new Domain.Interop.API.Connect.Clients.VehiclesAPIConnectClient(httpClientHelperProvider);
            var propertyPropousalAPIConnectClient = new Leasing.Interop.API.Connect.Clients.PropertyLeasePropousalsAPIConnectClient(httpClientHelperProvider);
            var vehiclePropousalAPIConnectClient = new Leasing.Interop.API.Connect.Clients.VehicleLeasePropousalsAPIConnectClient(httpClientHelperProvider);
            var propertyOfferAPIConnectClient = new Leasing.Interop.API.Connect.Clients.PropertyLeaseOffersAPIConnectClient(httpClientHelperProvider);
            var vehicleOfferAPIConnectClient = new Leasing.Interop.API.Connect.Clients.VehicleLeaseOffersAPIConnectClient(httpClientHelperProvider);
            var propertyOrganizationPostulationAPIConnectClient = new Leasing.Interop.API.Connect.Clients.PropertyLeaseOrganizationPostulationsAPIConnectClient(httpClientHelperProvider);
            var propertyPersonPostulationAPIConnectClient = new Leasing.Interop.API.Connect.Clients.PropertyLeasePersonPostulationsAPIConnectClient(httpClientHelperProvider);
            var vehicleOrganizationPostulationAPIConnectClient = new Leasing.Interop.API.Connect.Clients.VehicleLeaseOrganizationPostulationsAPIConnectClient(httpClientHelperProvider);
            var vehiclePersonPostulationAPIConnectClient = new Leasing.Interop.API.Connect.Clients.VehicleLeasePersonPostulationsAPIConnectClient(httpClientHelperProvider);
            var legalClientPropertyLeasingAPIConnectClient = new Leasing.Interop.API.Connect.Clients.LegalClientPropertyLeasingsAPIConnectClient(httpClientHelperProvider);
            var naturalClientPropertyLeasingAPIConnectClient = new Leasing.Interop.API.Connect.Clients.NaturalClientPropertyLeasingsAPIConnectClient(httpClientHelperProvider);            
            var legalClientVehicleLeasingAPIConnectClient = new Leasing.Interop.API.Connect.Clients.LegalClientVehicleLeasingsAPIConnectClient(httpClientHelperProvider);
            var naturalClientVehicleLeasingAPIConnectClient = new Leasing.Interop.API.Connect.Clients.NaturalClientVehicleLeasingsAPIConnectClient(httpClientHelperProvider);

            var propertyPropousalCount = await propertyPropousalAPIConnectClient.CountAsync();
            var vehiclePropousalCount = await vehiclePropousalAPIConnectClient.CountAsync();
            var propertyOfferCount = await propertyOfferAPIConnectClient.CountAsync();
            var vehicleOfferCount = await vehicleOfferAPIConnectClient.CountAsync();
            var propertyOrganizationPostulationCount = await propertyOrganizationPostulationAPIConnectClient.CountAsync();
            var propertyPersonPostulationCount = await propertyPersonPostulationAPIConnectClient.CountAsync();
            var vehicleOrganizationPostulationCount = await vehicleOrganizationPostulationAPIConnectClient.CountAsync();
            var vehiclePersonPostulationCount = await vehiclePersonPostulationAPIConnectClient.CountAsync();
            
            var properties = await propertiesAPIConnectClient.GetAsync();
            var vehicles = await vehiclesAPIConnectClient.GetAsync();

            var legalClientPropertyLeasings = await legalClientPropertyLeasingAPIConnectClient.GetAsync();
            var naturalClientPropertyLeasings = await naturalClientPropertyLeasingAPIConnectClient.GetAsync();
            var legalClientVehicleLeasings = await legalClientVehicleLeasingAPIConnectClient.GetAsync();
            var naturalClientVehicleLeasings = await naturalClientVehicleLeasingAPIConnectClient.GetAsync();

            var endingContractCount = 0;
            var endedContractCount = 0;

            var vehicleLeasingDictionary = new System.Collections.Generic.Dictionary<Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, int>();

            var now = System.DateTime.Now;

            foreach (var model in legalClientVehicleLeasings)
            {
                if (model.Contract.DurationUnitCount != null && model.Contract.DurationUnitCount.Value > 0)
                {
                    var limitDateTime = model.Contract.StarAt;

                    switch (model.Contract.DurationUnitMeasureKind.Value)
                    {
                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Years:
                            limitDateTime = limitDateTime.AddYears(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Months:
                            limitDateTime = limitDateTime.AddMonths(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Days:
                            limitDateTime = limitDateTime.AddDays(model.Contract.DurationUnitCount.Value);
                            
                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Hours:
                        default:
                            limitDateTime = limitDateTime.AddHours(model.Contract.DurationUnitCount.Value);

                            break;
                    }

                    if (limitDateTime < now)
                    {
                        endedContractCount++;
                    }
                    else if (limitDateTime - now < System.TimeSpan.FromDays(45))
                    {
                        endingContractCount++;
                    }
                }

                var prospectKey = $"L-{model.Contract.Client.Contact.BusinessKind.Id}";

                var founded = false;

                foreach (var item in vehicleLeasingDictionary.Keys)
                {
                    var currentKey = $"L-{item.Id}";

                    if (!currentKey.Equals(prospectKey)) continue;

                    vehicleLeasingDictionary[item] = vehicleLeasingDictionary[item] + 1;

                    founded = true;

                    break;
                }

                if (!founded)
                {
                    vehicleLeasingDictionary.Add(model.Contract.Client.Contact.BusinessKind, 1);
                }
            }

            foreach (var model in naturalClientVehicleLeasings)
            {
                if (model.Contract.DurationUnitCount != null && model.Contract.DurationUnitCount.Value > 0)
                {
                    var limitDateTime = model.Contract.StarAt;

                    switch (model.Contract.DurationUnitMeasureKind.Value)
                    {
                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Years:
                            limitDateTime = limitDateTime.AddYears(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Months:
                            limitDateTime = limitDateTime.AddMonths(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Days:
                            limitDateTime = limitDateTime.AddDays(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Hours:
                        default:
                            limitDateTime = limitDateTime.AddHours(model.Contract.DurationUnitCount.Value);

                            break;
                    }

                    if (limitDateTime < now)
                    {
                        endedContractCount++;
                    }
                    else if (limitDateTime - now < System.TimeSpan.FromDays(45))
                    {
                        endingContractCount++;
                    }
                }

                var prospectKey = $"N-{model.Contract.Client.Contact.BusinessKind.Id}";

                var founded = false;

                foreach (var item in vehicleLeasingDictionary.Keys)
                {
                    var currentKey = $"N-{item.Id}";

                    if (!currentKey.Equals(prospectKey)) continue;

                    vehicleLeasingDictionary[item] = vehicleLeasingDictionary[item] + 1;

                    founded = true;

                    break;
                }

                if (!founded)
                {
                    vehicleLeasingDictionary.Add(model.Contract.Client.Contact.BusinessKind, 1);
                }
            }

            var vehicleLeasingPieCharSeries = new System.Collections.Generic.List<LiveChartsCore.SkiaSharpView.PieSeries<int>>();

            foreach (var item in vehicleLeasingDictionary)
            {
                vehicleLeasingPieCharSeries.Add(new LiveChartsCore.SkiaSharpView.PieSeries<int>
                {
                    Values = new int[] { item.Value },
                    MaxRadialColumnWidth = 48,
                    Name = item.Key.Name,
                    Stroke = null
                });
            }

            var propertyLeasingDictionary = new System.Collections.Generic.Dictionary<Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, int>();

            foreach (var model in legalClientPropertyLeasings)
            {
                if (model.Contract.DurationUnitCount != null && model.Contract.DurationUnitCount.Value > 0)
                {
                    var limitDateTime = model.Contract.StarAt;

                    switch (model.Contract.DurationUnitMeasureKind.Value)
                    {
                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Years:
                            limitDateTime = limitDateTime.AddYears(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Months:
                            limitDateTime = limitDateTime.AddMonths(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Days:
                            limitDateTime = limitDateTime.AddDays(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Hours:
                        default:
                            limitDateTime.AddHours(model.Contract.DurationUnitCount.Value);

                            break;
                    }

                    if (limitDateTime < now)
                    {
                        endedContractCount++;
                    }
                    else if (limitDateTime - now < System.TimeSpan.FromDays(45))
                    {
                        endingContractCount++;
                    }
                }

                var prospectKey = $"L-{model.Contract.Client.Contact.BusinessKind.Id}";

                var founded = false;

                foreach (var item in propertyLeasingDictionary.Keys)
                {
                    var currentKey = $"L-{item.Id}";

                    if (!currentKey.Equals(prospectKey)) continue;

                    propertyLeasingDictionary[item] = propertyLeasingDictionary[item] + 1;

                    founded = true;

                    break;
                }

                if (!founded)
                {
                    propertyLeasingDictionary.Add(model.Contract.Client.Contact.BusinessKind, 1);
                }
            }

            foreach (var model in naturalClientPropertyLeasings)
            {
                if (model.Contract.DurationUnitCount != null && model.Contract.DurationUnitCount.Value > 0)
                {
                    var limitDateTime = model.Contract.StarAt;

                    switch (model.Contract.DurationUnitMeasureKind.Value)
                    {
                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Years:
                            limitDateTime = limitDateTime.AddYears(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Months:
                            limitDateTime = limitDateTime.AddMonths(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Days:
                            limitDateTime = limitDateTime.AddDays(model.Contract.DurationUnitCount.Value);

                            break;

                        case Legal.Persistence.Enumerations.DurationUnitMeasureKind.Hours:
                        default:
                            limitDateTime = limitDateTime.AddHours(model.Contract.DurationUnitCount.Value);

                            break;
                    }

                    if (limitDateTime < now)
                    {
                        endedContractCount++;
                    }
                    else if (limitDateTime - now < System.TimeSpan.FromDays(45))
                    {
                        endingContractCount++;
                    }
                }

                var prospectKey = $"N-{model.Contract.Client.Contact.BusinessKind.Id}";

                var founded = false;

                foreach (var item in propertyLeasingDictionary.Keys)
                {
                    var currentKey = $"N-{item.Id}";

                    if (!currentKey.Equals(prospectKey)) continue;
                        
                    propertyLeasingDictionary[item] = propertyLeasingDictionary[item] + 1;

                    founded = true;

                    break;
                }

                if (!founded)
                {
                    propertyLeasingDictionary.Add(model.Contract.Client.Contact.BusinessKind, 1);
                }
            }

            var propertyLeasingPieCharSeries = new System.Collections.Generic.List<LiveChartsCore.SkiaSharpView.PieSeries<int>>();

            foreach (var item in propertyLeasingDictionary)
            {
                propertyLeasingPieCharSeries.Add(new LiveChartsCore.SkiaSharpView.PieSeries<int>
                {
                    Values = new int[] { item.Value },
                    MaxRadialColumnWidth = 48,
                    Name = item.Key.Name,
                    Stroke = null
                });
            }

            var propertySpaces = new System.Collections.Generic.List<Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel>();

            foreach ( var property in properties)
            {
                propertySpaces.AddRange(property.Spaces);
            }

            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.PropousalCount = propertyPropousalCount + vehiclePropousalCount;
                BindingContextPageModel.OfferCount = propertyOfferCount + vehicleOfferCount;
                BindingContextPageModel.PostulationCount = propertyOrganizationPostulationCount + vehicleOrganizationPostulationCount + propertyPersonPostulationCount + vehiclePersonPostulationCount;
                BindingContextPageModel.LeasingCount = legalClientPropertyLeasings.LongLength + naturalClientPropertyLeasings.LongLength + legalClientVehicleLeasings.LongLength + naturalClientVehicleLeasings.LongLength;
                BindingContextPageModel.EndingContractCount = endingContractCount;
                BindingContextPageModel.EndedContractCount = endedContractCount;
                BindingContextPageModel.IsVehicleAssignmentPieChartMock = vehicles.Length <= 0;
                BindingContextPageModel.VehicleAssignmentPieChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { BindingContextPageModel.IsVehicleAssignmentPieChartMock ? System.Random.Shared.Next(1, 25) : vehicles.Where(model => model.Assignment == null).Count() },
                        Name = "Disponibles",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { BindingContextPageModel.IsVehicleAssignmentPieChartMock ? System.Random.Shared.Next(1, 25) : vehicles.Where(model => model.Assignment == Domain.Persistence.Enumerations.VehicleAssignment.Fleet).Count() },
                        Name = "Operaciones",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { BindingContextPageModel.IsVehicleAssignmentPieChartMock ? System.Random.Shared.Next(1, 25) : vehicles.Where(model => model.Assignment == Domain.Persistence.Enumerations.VehicleAssignment.Leasing).Count() },
                        Name = "Arrendamiento",
                        Stroke = null
                    }
                };
                BindingContextPageModel.IsPropertySpaceAssignmentPieChartMock = propertySpaces.Count <= 0;
                BindingContextPageModel.PropertySpaceAssignmentPieChart.Series = new[]
                {
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { BindingContextPageModel.IsPropertySpaceAssignmentPieChartMock ? System.Random.Shared.Next(1, 50) : propertySpaces.Where(model => model.Assignment == null).Count() },
                        Name = "Disponibles",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { BindingContextPageModel.IsPropertySpaceAssignmentPieChartMock ? System.Random.Shared.Next(1, 50) : propertySpaces.Where(model => model.Assignment == Domain.Persistence.Enumerations.PropertyAssignment.Operation).Count() },
                        Name = "Operaciones",
                        Stroke = null
                    },
                    new LiveChartsCore.SkiaSharpView.PieSeries<int>
                    {
                        Values = new int[] { BindingContextPageModel.IsPropertySpaceAssignmentPieChartMock ? System.Random.Shared.Next(1, 50) : propertySpaces.Where(model => model.Assignment == Domain.Persistence.Enumerations.PropertyAssignment.Leasing).Count() },
                        Name = "Arrendamiento",
                        Stroke = null
                    }
                };
                BindingContextPageModel.IsVehicleLeasingPieChartMock = vehicleLeasingPieCharSeries.Count <= 0;
                BindingContextPageModel.VehicleLeasingPieChart.Series = BindingContextPageModel.IsVehicleLeasingPieChartMock ? GeMockLeasingPieCharSeries() : vehicleLeasingPieCharSeries.ToArray();
                BindingContextPageModel.IsPropertyLeasingPieChartMock = propertyLeasingPieCharSeries.Count <= 0;
                BindingContextPageModel.PropertyLeasingPieChart.Series = BindingContextPageModel.IsPropertyLeasingPieChartMock ? GeMockLeasingPieCharSeries() : propertyLeasingPieCharSeries.ToArray();
                BindingContextPageModel.IsClientPaymentPertinenceHeatChartMock = true;
                BindingContextPageModel.ClientPaymentPertinenceHeatChart = new Models.View.ChartViewModel
                {
                    XAxes = [
                        new LiveChartsCore.SkiaSharpView.Axis
                        {
                            LabelsRotation = -45,
                            Labels = ["Cliente 1", "Cliente 2", "Cliente 3", "Cliente 4", "Cliente 5", "Cliente 6", "Cliente 7", "Cliente 8"],
                            ForceStepToMin = true,
                            MinStep = 1
                        }
                    ],
                    YAxes = [
                        new LiveChartsCore.SkiaSharpView.Axis
                        {
                            Labels = ["Sep", "Ago", "Jul", "Jun", "May", "Abr"],
                            ForceStepToMin = true,
                            MinStep = 1
                        }
                    ],
                    Series = new[]
                    {
                        new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint>
                        {
                            Values = new LiveChartsCore.Defaults.WeightedPoint[] {
                                // Charles
                                new(0, 0, System.Random.Shared.Next(1, 30)), // Jan
                                new(0, 1, System.Random.Shared.Next(1, 30)), // Feb
                                new(0, 2, System.Random.Shared.Next(1, 30)), // Mar

                                // Richard
                                new(1, 0, System.Random.Shared.Next(1, 30)), // Jan
                                new(1, 1, System.Random.Shared.Next(1, 30)), // Feb
                                new(1, 2, System.Random.Shared.Next(1, 30)), // Mar
                                new(1, 3, System.Random.Shared.Next(1, 30)), // Apr
                                new(1, 4, System.Random.Shared.Next(1, 30)), // May
                                new(1, 5, System.Random.Shared.Next(1, 30)), // Jun

                                // Ana
                                new(2, 0, System.Random.Shared.Next(1, 30)), // Jan
                                new(2, 1, System.Random.Shared.Next(1, 30)), // Feb
                                new(2, 2, System.Random.Shared.Next(1, 30)), // Mar
                                new(2, 3, System.Random.Shared.Next(1, 30)), // Apr
                                new(2, 4, System.Random.Shared.Next(1, 30)), // May

                                // Mari
                                new(3, 0, System.Random.Shared.Next(1, 30)), // Jan
                                new(3, 1, System.Random.Shared.Next(1, 30)), // Feb
                                new(3, 2, System.Random.Shared.Next(1, 30)), // Mar
                                new(3, 3, System.Random.Shared.Next(1, 30)), // Apr
                                new(3, 4, System.Random.Shared.Next(1, 30)), // May
                                new(3, 5, System.Random.Shared.Next(1, 30)), // Jun

                                // Charles
                                new(4, 0, System.Random.Shared.Next(1, 30)), // Jan
                                new(4, 1, System.Random.Shared.Next(1, 30)), // Feb
                                new(4, 2, System.Random.Shared.Next(1, 30)), // Mar
                                new(4, 3, System.Random.Shared.Next(1, 30)), // Apr
                                new(4, 4, System.Random.Shared.Next(1, 30)), // May
                                new(4, 5, System.Random.Shared.Next(1, 30)), // Jun

                                // Richard
                                new(5, 0, System.Random.Shared.Next(1, 30)), // Jan
                                new(5, 1, System.Random.Shared.Next(1, 30)), // Feb
                                new(5, 2, System.Random.Shared.Next(1, 30)), // Mar
                                new(5, 3, System.Random.Shared.Next(1, 30)), // Apr
                                new(5, 4, System.Random.Shared.Next(1, 30)), // May
                                new(5, 5, System.Random.Shared.Next(1, 30)), // Jun

                                // Ana
                                new(6, 0, System.Random.Shared.Next(1, 30)), // Jan
                                new(6, 1, System.Random.Shared.Next(1, 30)), // Feb
                                new(6, 2, System.Random.Shared.Next(1, 30)), // Mar
                                new(6, 3, System.Random.Shared.Next(1, 30)), // Apr

                                // Mari
                                new(7, 0, System.Random.Shared.Next(1, 30)), // Jan
                                new(7, 1, System.Random.Shared.Next(1, 30)), // Feb
                                new(7, 2, System.Random.Shared.Next(1, 30)), // Mar
                                new(7, 3, System.Random.Shared.Next(1, 30)), // Apr
                                new(7, 4, System.Random.Shared.Next(1, 30)), // May
                                new(7, 5, System.Random.Shared.Next(1, 30)), // Jun
                            }
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

    private LiveChartsCore.SkiaSharpView.PieSeries<int>[] GeMockLeasingPieCharSeries()
    {
        var result = new System.Collections.Generic.List<LiveChartsCore.SkiaSharpView.PieSeries<int>>();

        for (int i = 1; i <= 3; i++)
        {
            result.Add(new LiveChartsCore.SkiaSharpView.PieSeries<int>
            {
                Values = new int[] { System.Random.Shared.Next(1, 25) },
                MaxRadialColumnWidth = 48,
                Name = $"Tipo de cliente {i}",
                Stroke = null
            });
        }

        return result.ToArray();
    }
}