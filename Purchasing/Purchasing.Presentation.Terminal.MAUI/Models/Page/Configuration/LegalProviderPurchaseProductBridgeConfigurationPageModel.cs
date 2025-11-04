namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalProviderPurchaseProductBridgeConfigurationPageModel : Contract.AbstractProviderPurchaseProductBridgeModel<Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel>
    {
        private Commercial.Interop.API.Common.Models.Display.LegalProviderDisplayModel provider;

        public LegalProviderPurchaseProductBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Provider = model.Provider;
            }
        }

        public Commercial.Interop.API.Common.Models.Display.LegalProviderDisplayModel Provider { get => provider; set => SetProperty(ref provider, value); }
    }
}
