namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge.Contract
{
    public abstract class AbstractProviderPurchaseProductBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public decimal Amount { get; set; }

        public decimal Cost { get; set; }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get; set; }
    }
}
