using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalProviderPurchaseProductBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel>
{
    public NaturalProviderPurchaseProductBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel> successAction, Models.Page.Configuration.NaturalProviderPurchaseProductBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.UnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.UnitMeasurement.Id != current.Id) continue;

                UnitMeasurementPicker.SelectedIndex = i;
                UnitMeasurementPicker.SelectedItem = current;

                break;
            }
        }

        if (model.CostCenter != null)
        {
            for (int i = 0; i < model.AvailableCostCenters.Length; i++)
            {
                var current = model.AvailableCostCenters[i];

                if (model.CostCenter.Id != current.Id) continue;

                CostCenterPicker.SelectedIndex = i;
                CostCenterPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Compra a Proveedor Natural";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.NaturalProviderPurchaseProductBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel
        {
            Provider = concreteBindingContext.Provider,
            Product = concreteBindingContext.Product,
            Amount = concreteBindingContext.Amount,
            UnitMeasurement = concreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex],
            Cost = concreteBindingContext.Cost,
            CostCenter = concreteBindingContext.AvailableCostCenters[CostCenterPicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.NaturalProviderPurchaseProductBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel
        {
            Provider = concreteBindingContext.Provider,
            Product = concreteBindingContext.Product,
            Amount = concreteBindingContext.Amount,
            UnitMeasurement = concreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex],
            Cost = concreteBindingContext.Cost,
            CostCenter = concreteBindingContext.AvailableCostCenters[CostCenterPicker.SelectedIndex]
        });
    }

    private void ProductChangeButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.ProductPickPage(ProductPickComplete_Callback)));
    }

    private void ProviderPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.NaturalProviderPickPage(ProviderPickComplete_Callback)));
    }

    private void ProductPickComplete_Callback(Inventory.Interop.API.Common.Models.Display.ProductDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.NaturalProviderPurchaseProductBridgeConfigurationPageModel)BindingContext;

        if (concreteBindingContext.Product == null || concreteBindingContext.Product.Id != model.Id)
        {
            concreteBindingContext.IsBusy = true;

            var unitMeasurementsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

            unitMeasurementsAPIConnectClient.GetReleatedsAsync(model.DefaultUnitMeasurement.Id).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.AvailableUnitMeasurements = task.Result;
                    concreteBindingContext.IsBusy = false;
                });
            });
        }

        concreteBindingContext.Product = model;

        hasChangesFlag = true;
    }

    private void ProviderPickComplete_Callback(Interop.API.Common.Models.Display.NaturalProviderDisplayModel model)
    {
        ((Models.Page.Configuration.NaturalProviderPurchaseProductBridgeConfigurationPageModel)BindingContext).Provider = model;

        hasChangesFlag = true;
    }
}