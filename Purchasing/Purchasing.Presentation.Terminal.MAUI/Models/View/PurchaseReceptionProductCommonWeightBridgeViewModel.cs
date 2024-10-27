namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.View
{
    public class PurchaseReceptionProductCommonWeightBridgeViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private decimal amount;

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }
    }
}
