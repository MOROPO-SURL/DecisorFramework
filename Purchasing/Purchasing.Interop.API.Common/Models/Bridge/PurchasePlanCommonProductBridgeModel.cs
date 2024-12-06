namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class PurchasePlanCommonProductBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Amount { get; set; }

        public Inventory.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1:F2} {2})", Product.Name, Amount, UnitMeasurement.Symbol);
        }
    }
}
