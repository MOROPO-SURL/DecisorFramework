namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class PurchaseZoneConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Models.Page.Configuration.PurchaseZoneConfigurationPageModel, Pages.Configuration.PurchaseZoneConfigurationPage>
    {
        public Pages.Configuration.PurchaseZoneConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> configurationSuccessAction, Models.Page.Configuration.PurchaseZoneConfigurationPageModel model)
        {
            return new Pages.Configuration.PurchaseZoneConfigurationPage(configurationSuccessAction, model);
        }
    }
}
