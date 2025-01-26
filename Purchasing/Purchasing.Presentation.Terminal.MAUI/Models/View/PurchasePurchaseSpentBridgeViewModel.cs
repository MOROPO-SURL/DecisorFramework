namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.View
{
    public class PurchasePurchaseSpentBridgeViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private decimal amount;
        private int count;

        public Interop.API.Common.Models.Display.PurchaseSpentDisplayModel Spent { get; set; }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); } // Unitario

        public int Count { get => count; set => SetProperty(ref count, value); }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get; set; }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel[] AvailableCostCenters { get; set; }
    }
}
