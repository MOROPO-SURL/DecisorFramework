namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseZoneSpentBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel>
    {
        private Interop.API.Common.Models.Display.PurchaseSpentDisplayModel spent;
        private decimal amount;

        public PurchaseZoneSpentBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Spent = model.Spent;
                Amount = model.Amount;
            }
        }

        public Interop.API.Common.Models.Display.PurchaseSpentDisplayModel Spent { get => spent; set => SetProperty(ref spent, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }
    }
}
