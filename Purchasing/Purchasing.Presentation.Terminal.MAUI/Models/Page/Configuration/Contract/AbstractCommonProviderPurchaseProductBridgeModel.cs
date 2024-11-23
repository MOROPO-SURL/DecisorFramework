using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractCommonProviderPurchaseProductBridgeModel<TProviderPurchaseProductBridgeModel> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TProviderPurchaseProductBridgeModel>
        where TProviderPurchaseProductBridgeModel : Interop.API.Common.Models.Bridge.Contract.AbstractProviderPurchaseProductBridgeModel
    {
        private Inventory.Interop.API.Common.Models.Display.ProductDisplayModel product;
        private decimal amount;
        private UnitMeasurementDisplayModel unitMeasurement;
        private decimal cost;
        private Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel costCenter;
        private UnitMeasurementDisplayModel[] availableUnitMeasurements;

        public AbstractCommonProviderPurchaseProductBridgeModel(TProviderPurchaseProductBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Product = model.Product;
                Amount = model.Amount;
                UnitMeasurement = model.UnitMeasurement;
                Cost = model.Cost;
            }
        }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get => product; set => SetProperty(ref product, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public decimal Cost { get => cost; set => SetProperty(ref cost, value); }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get => costCenter; set => SetProperty(ref costCenter, value); }

        public UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get => availableUnitMeasurements; set => SetProperty(ref availableUnitMeasurements, value); }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel[] AvailableCostCenters { get; set; }
    }
}
