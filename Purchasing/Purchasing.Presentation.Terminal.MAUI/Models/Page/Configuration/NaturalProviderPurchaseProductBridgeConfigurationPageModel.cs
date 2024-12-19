namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalProviderPurchaseProductBridgeConfigurationPageModel : Contract.AbstractCommonProviderPurchaseProductBridgeModel<Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel>
    {
        private Commercial.Interop.API.Common.Models.Display.NaturalProviderDisplayModel provider;

        public NaturalProviderPurchaseProductBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Provider = model.Provider;
                CostCenter = model.CostCenter;
            }
        }

        public Commercial.Interop.API.Common.Models.Display.NaturalProviderDisplayModel Provider { get => provider; set => SetProperty(ref provider, value); }
    }
}
