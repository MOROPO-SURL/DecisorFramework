namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class PurchasePlanCommonProductBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Amount { get; set; }

        public Essential.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }
    }
}
