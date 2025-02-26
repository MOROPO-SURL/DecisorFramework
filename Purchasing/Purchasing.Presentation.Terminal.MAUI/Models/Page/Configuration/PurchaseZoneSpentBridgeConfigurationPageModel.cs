namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseZoneSpentBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel>
    {
        private Interop.API.Common.Models.Display.PurchaseSpentDisplayModel spent;
        private decimal amount;
        private Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel currency;

        public PurchaseZoneSpentBridgeConfigurationPageModel() : this(null) { }

        public PurchaseZoneSpentBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Spent = model.Spent;
                Amount = model.Amount;
                currency = model.Currency;
            }
        }

        public Interop.API.Common.Models.Display.PurchaseSpentDisplayModel Spent { get => spent; set => SetProperty(ref spent, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel Currency { get => currency; set => SetProperty(ref currency, value); }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel[] AvailableCurrrencies { get; set; }
    }
}
