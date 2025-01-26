namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.View
{
    public class PurchaseReceptionWeightsByCostCenterViewModel
    {
        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get; set; }

        public PurchaseReceptionProductWeightBridgeViewModel[] ProductWeights { get; set; }
    }
}
