namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class PurchaseZoneSpentBridgeModel
    {
        public Display.PurchaseSpentDisplayModel Spent { get; set; }

        public decimal Amount { get; set; }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel Currency { get; set; }
    }
}
