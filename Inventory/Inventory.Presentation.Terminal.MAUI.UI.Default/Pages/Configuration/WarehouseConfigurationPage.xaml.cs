using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WarehouseConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WarehouseDisplayModel, Interop.API.Common.Models.Display.WarehouseDisplayModel, Models.Page.Configuration.WarehouseConfigurationPageModel>
{
    private readonly List<Interop.API.Common.Models.Input.WarehousingAreaInputModel> editionAreas = [];
    private readonly List<Interop.API.Common.Models.Input.WarehousingAreaInputModel> incomingAreas = [];
    private readonly List<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel> outgoingAreas = [];

    public WarehouseConfigurationPage(System.Action<Interop.API.Common.Models.Display.WarehouseDisplayModel> successAction, Models.Page.Configuration.WarehouseConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Almacen";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WarehouseDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WarehousesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.WarehouseInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            IncomingAreas = incomingAreas
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WarehouseDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WarehousesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.WarehouseInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            IncomingAreas = incomingAreas,
            EditionAreas = editionAreas,
            OutgoingAreas = outgoingAreas
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void AreaAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
                var familiesAPIConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.WarehousingAreaConfigurationPageModel(null)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync(),
                    AvailableFamilies = await familiesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new WarehousingAreaConfigurationPage(AreaCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void AreaEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
                var familiesAPIConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.WarehousingAreaConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.WarehousingAreaDisplayModel)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync(),
                    AvailableFamilies = await familiesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new WarehousingAreaConfigurationPage(AreaEditSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void AreaRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta área de almacenamiento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.WarehousingAreaDisplayModel;

                var handled = false;

                foreach (var item in incomingAreas)
                {
                    if (item.Id != target.Id) continue;

                    incomingAreas.Remove(editionAreas.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionAreas)
                    {
                        if (item.Id != target.Id) continue;

                        editionAreas.Remove(editionAreas.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingAreas.Add(target);
                }

                ConcreteBindingContext.Areas.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void AreaCreateSuccess_Callback(Interop.API.Common.Models.Display.WarehousingAreaDisplayModel model)
    {
        incomingAreas.Add(new Interop.API.Common.Models.Input.WarehousingAreaInputModel
        {
            Id = model.Id,
            Name = model.Name,
            Capacity = model.Capacity,
            UnitMeasurementId = model.UnitMeasurement.Id,
            Description = model.Description,
            FamilyId = model.Family.Id
        });

        ConcreteBindingContext.Areas.Add(model);

        hasChangesFlag = true;
    }

    private void AreaEditSuccess_Callback(Interop.API.Common.Models.Display.WarehousingAreaDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingAreas)
        {
            if (item.Id != model.Id) continue;

            item.Name = model.Name;
            item.Capacity = model.Capacity;
            item.UnitMeasurementId = model.UnitMeasurement.Id;
            item.Description = model.Description;
            item.FamilyId = model.Family.Id;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionAreas)
            {
                if (item.Id != model.Id) continue;

                item.Name = model.Name;
                item.Capacity = model.Capacity;
                item.UnitMeasurementId = model.UnitMeasurement.Id;
                item.Description = model.Description;
                item.FamilyId = model.Family.Id;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionAreas.Add(new Interop.API.Common.Models.Input.WarehousingAreaInputModel
            {
                Id = model.Id,
                Name = model.Name,
                Capacity = model.Capacity,
                UnitMeasurementId = model.UnitMeasurement.Id,
                Description = model.Description,
                FamilyId = model.Family.Id
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Areas)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Areas[index] = model;

            break;
        }

        hasChangesFlag = true;
    }
}