namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class PurchasePurchaseSpentBridgeModel
    {
        public Display.PurchaseSpentDisplayModel Spent { get; set; }

        public decimal Amount { get; set; }

        public decimal Cost { get; set; } // Unitario

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get; set; }
    }
}
