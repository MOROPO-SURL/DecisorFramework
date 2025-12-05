namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractProviderPurchaseProductBridgeModel<TProviderPurchaseProductBridgeModel> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TProviderPurchaseProductBridgeModel>
        where TProviderPurchaseProductBridgeModel : Interop.API.Common.Models.Bridge.Contract.AbstractProviderPurchaseProductBridgeModel
    {
        private Inventory.Interop.API.Common.Models.Display.ProductDisplayModel product;
        private decimal amount;
        private Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;
        private decimal cost;
        private Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel costCenter;
        private Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] availableUnitMeasurements;

        public AbstractProviderPurchaseProductBridgeModel(TProviderPurchaseProductBridgeModel model = null) : base(model)
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

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public decimal Cost { get => cost; set => SetProperty(ref cost, value); }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get => costCenter; set => SetProperty(ref costCenter, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get => availableUnitMeasurements; set => SetProperty(ref availableUnitMeasurements, value); }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel[] AvailableCostCenters { get; set; }
    }
}
