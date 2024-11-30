namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge
{
    public class ProductionProductBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Amount { get; set; }

        public Inventory.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }
    }
}
