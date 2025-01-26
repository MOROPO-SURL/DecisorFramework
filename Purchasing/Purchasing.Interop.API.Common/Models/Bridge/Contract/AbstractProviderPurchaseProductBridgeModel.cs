using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge.Contract
{
    public abstract class AbstractProviderPurchaseProductBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public decimal Amount { get; set; }

        public decimal Cost { get; set; }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get; set; }
    }
}
