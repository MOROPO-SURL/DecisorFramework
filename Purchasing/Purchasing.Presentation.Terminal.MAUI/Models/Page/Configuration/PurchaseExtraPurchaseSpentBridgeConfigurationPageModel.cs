namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseExtraPurchaseSpentBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<View.PurchasePurchaseSpentBridgeViewModel>
    {
        private Interop.API.Common.Models.Display.PurchaseSpentDisplayModel spent;
        private decimal amount;
        private int count;
        private Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel costCenter;

        public PurchaseExtraPurchaseSpentBridgeConfigurationPageModel(View.PurchasePurchaseSpentBridgeViewModel model = null) : base(model)
        {
            if (model != null)
            {
                Spent = model.Spent;
                Amount = model.Amount;
                Count = model.Count;
                CostCenter = model.CostCenter;
            }
        }

        public Interop.API.Common.Models.Display.PurchaseSpentDisplayModel Spent { get => spent; set => SetProperty(ref spent, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public int Count { get => count; set => SetProperty(ref count, value); }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get => costCenter; set => SetProperty(ref costCenter, value); }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel[] AvailableCostCenters { get; set; }
    }
}
