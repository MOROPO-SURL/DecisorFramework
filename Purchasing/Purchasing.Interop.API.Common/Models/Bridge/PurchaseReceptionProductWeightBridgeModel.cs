namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class PurchaseReceptionProductWeightBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Amount { get; set; }

        public decimal Decrease { get; set; }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get; set; }
    }
}
