using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchasePlanConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.PurchasePlanDisplayModel>
{
    public PurchasePlanConfigurationPage(System.Action<Interop.API.Common.Models.Display.PurchasePlanDisplayModel> successAction, Models.Page.Configuration.PurchasePlanConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Zone != null)
        {
            for (int i = 0; i < model.AvailableZones.Length; i++)
            {
                var current = model.AvailableZones[i];

                if (model.Zone.Id != current.Id) continue;

                ZonePicker.SelectedIndex = i;
                ZonePicker.SelectedItem = current;

                break;
            }
        }

        if (model.Planner != null)
        {
            for (int i = 0; i < model.AvailablePlanners.Length; i++)
            {
                var current = model.AvailablePlanners[i];

                if (model.Planner.Id != current.Id) continue;

                PlannerPicker.SelectedIndex = i;
                PlannerPicker.SelectedItem = current;

                break;
            }
        }

        if (model.Responsible != null)
        {
            for (int i = 0; i < model.AvailableResponsibles.Length; i++)
            {
                var current = model.AvailableResponsibles[i];

                if (model.Responsible.Id != current.Id) continue;

                ResponsiblePicker.SelectedIndex = i;
                ResponsiblePicker.SelectedItem = current;

                break;
            }
        }

        if (model.Decisor != null)
        {
            for (int i = 0; i < model.AvailableDecisors.Length; i++)
            {
                var current = model.AvailableDecisors[i];

                if (model.Decisor.Id != current.Id) continue;

                DecisorPicker.SelectedIndex = i;
                DecisorPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Plan de Compra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchasePlanDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchasePlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PurchasePlanInputModel
        {
            Id = System.Guid.NewGuid(),
            PlannedFor = concreteBindingContext.PlannedFor,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            ZoneId = concreteBindingContext.AvailableZones[ZonePicker.SelectedIndex].Id,
            PlannerId = concreteBindingContext.AvailablePlanners[PlannerPicker.SelectedIndex].Id,
            ResponsibleId = concreteBindingContext.AvailableResponsibles[ResponsiblePicker.SelectedIndex].Id,
            DecisorId = concreteBindingContext.AvailableDecisors[DecisorPicker.SelectedIndex].Id,
            LegalProviderBridges = concreteBindingContext.LegalProviderBridges.ToList(),
            NaturalProviderBridges = concreteBindingContext.NaturalProviderBridges.ToList(),
            InputProductBridges = concreteBindingContext.InputProductBridges.ToList(),
            OutputProductBridges = concreteBindingContext.OutputProductBridges.ToList()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchasePlanDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchasePlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PurchasePlanInputModel
        {
            Id = concreteBindingContext.Id,
            PlannedFor = concreteBindingContext.PlannedFor,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            ZoneId = concreteBindingContext.AvailableZones[ZonePicker.SelectedIndex].Id,
            PlannerId = concreteBindingContext.AvailablePlanners[PlannerPicker.SelectedIndex].Id,
            ResponsibleId = concreteBindingContext.AvailableResponsibles[ResponsiblePicker.SelectedIndex].Id,
            DecisorId = concreteBindingContext.AvailableDecisors[DecisorPicker.SelectedIndex].Id,
            LegalProviderBridges = concreteBindingContext.LegalProviderBridges.ToList(),
            NaturalProviderBridges = concreteBindingContext.NaturalProviderBridges.ToList(),
            InputProductBridges = concreteBindingContext.InputProductBridges.ToList(),
            OutputProductBridges = concreteBindingContext.OutputProductBridges.ToList()
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void AddLegalProviderButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.LegalProviderPickPage(LegalProviderPickComplete_Callback)));
    }

    private void AddNaturalProviderButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.NaturalProviderPickPage(NaturalProviderPickComplete_Callback)));
    }

    private void AddInputProductBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Essential.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel(null)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchasePlanCommonProductBridgeConfigurationPage("Previsión de Insumo", PurchasePlanInputProductBridgeCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void AddOutputProductBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Essential.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel(null)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchasePlanCommonProductBridgeConfigurationPage("Previsión de Producto", PurchasePlanOutputProductBridgeCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void EditInputProductBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Essential.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchasePlanCommonProductBridgeConfigurationPage("Previsión de Insumo", PurchasePlanInputProductBridgeEditSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void EditOutputProductBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Essential.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchasePlanCommonProductBridgeConfigurationPage("Previsión de Producto", PurchasePlanOutputProductBridgeEditSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void LegalProviderRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este proveedor legal del listado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext).LegalProviderBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchasePlanLegalProviderBridgeModel));
        });
    }

    private void NaturalProviderRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este proveedor natural del listado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext).NaturalProviderBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchasePlanNaturalProviderBridgeModel));
        });
    }

    private void PurchasePlanInputProductBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta previción de insumo?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext).InputProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel));
        });
    }

    private void PurchasePlanOutputProductBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta previción de producto?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext).OutputProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel));
        });
    }

    private void LegalProviderPickComplete_Callback(Interop.API.Common.Models.Display.LegalProviderDisplayModel model)
    {
        ((Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext).LegalProviderBridges.Add(new Interop.API.Common.Models.Bridge.PurchasePlanLegalProviderBridgeModel
        {
            Provider = model,
            Debt = 0
        });

        hasChangesFlag = true;
    }

    private void NaturalProviderPickComplete_Callback(Interop.API.Common.Models.Display.NaturalProviderDisplayModel model)
    {
        ((Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext).NaturalProviderBridges.Add(new Interop.API.Common.Models.Bridge.PurchasePlanNaturalProviderBridgeModel
        {
            Provider = model,
            Debt = 0
        });

        hasChangesFlag = true;
    }

    private void PurchasePlanInputProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel model)
    {
        ((Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext).InputProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void PurchasePlanOutputProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel model)
    {
        ((Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext).OutputProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void PurchasePlanInputProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.InputProductBridges.First(item => item.Product.Id == model.Product.Id);

        var index = concreteBindingContext.InputProductBridges.IndexOf(reference);

        concreteBindingContext.InputProductBridges[index] = model;

        hasChangesFlag = true;
    }

    private void PurchasePlanOutputProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.OutputProductBridges.First(item => item.Product.Id == model.Product.Id);

        var index = concreteBindingContext.OutputProductBridges.IndexOf(reference);

        concreteBindingContext.OutputProductBridges[index] = model;

        hasChangesFlag = true;
    }
}