using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class PurchasePlanCommonProductBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Amount { get; set; }

        public UnitMeasurementDisplayModel UnitMeasurement { get; set; }
    }
}
