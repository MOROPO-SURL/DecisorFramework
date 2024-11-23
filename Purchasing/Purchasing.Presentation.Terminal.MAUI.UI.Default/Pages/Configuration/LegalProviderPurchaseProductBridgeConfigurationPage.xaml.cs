using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalProviderPurchaseProductBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel>
{
    public LegalProviderPurchaseProductBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel> successAction, Models.Page.Configuration.LegalProviderPurchaseProductBridgeConfigurationPageModel model) : base(successAction, model)
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

    protected override string EntityTypeName => "Compra a Proveedor Jurídico";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.LegalProviderPurchaseProductBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel
        {
            Provider = concreteBindingContext.Provider,
            Product = concreteBindingContext.Product,
            Amount = concreteBindingContext.Amount,
            UnitMeasurement = concreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex],
            Cost = concreteBindingContext.Cost,
            CostCenter = concreteBindingContext.AvailableCostCenters[CostCenterPicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.LegalProviderPurchaseProductBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.LegalProviderPickPage(ProviderPickComplete_Callback)));
    }

    private void ProductPickComplete_Callback(Inventory.Interop.API.Common.Models.Display.ProductDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.LegalProviderPurchaseProductBridgeConfigurationPageModel)BindingContext;

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

    private void ProviderPickComplete_Callback(Interop.API.Common.Models.Display.LegalProviderDisplayModel model)
    {
        ((Models.Page.Configuration.LegalProviderPurchaseProductBridgeConfigurationPageModel)BindingContext).Provider = model;

        hasChangesFlag = true;
    }
}