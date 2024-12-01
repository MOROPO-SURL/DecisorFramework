namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.View
{
    public class PurchaseReceptionProductWeightBridgeViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private decimal amount;

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public System.Collections.ObjectModel.ObservableCollection<BatchSpecificationViewModel> Batchs { get; set; } = new System.Collections.ObjectModel.ObservableCollection<BatchSpecificationViewModel>();
    }
}
