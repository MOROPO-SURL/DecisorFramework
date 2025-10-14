namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PurchaseZoneConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Models.Page.Configuration.PurchaseZoneConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Models.Page.Configuration.PurchaseZoneConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PurchaseZoneDisplayModel model)
        {
            return new Pages.Configuration.PurchaseZoneConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.PurchaseZoneConfigurationPageModel(model));
        }
    }
}
