namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PurchaseZoneConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Models.Page.Configuration.PurchaseZoneConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Models.Page.Configuration.PurchaseZoneConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> configurationSuccessAction, Models.Page.Configuration.PurchaseZoneConfigurationPageModel model)
        {
            return new Pages.Configuration.PurchaseZoneConfigurationPage(configurationSuccessAction, model);
        }
    }
}
