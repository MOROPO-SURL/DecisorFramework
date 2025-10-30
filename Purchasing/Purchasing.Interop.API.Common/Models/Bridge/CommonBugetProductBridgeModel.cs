namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class CommonBugetProductBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get; set; }

        public decimal UnitPrice { get; set; }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel Currency { get; set; }

        public decimal Amount { get; set; }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public override string ToString()
        {
            return Product.Name;
        }
    }
}
