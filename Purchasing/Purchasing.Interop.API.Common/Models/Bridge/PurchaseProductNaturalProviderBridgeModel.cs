namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class PurchaseProductNaturalProviderBridgeModel : Contract.AbstractProviderPurchaseProductBridgeModel
    {
        public Display.NaturalProviderDisplayModel Provider { get; set; }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get; set; }
    }
}
