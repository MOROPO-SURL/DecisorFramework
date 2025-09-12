namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ProductConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductDisplayModel, Models.Page.Configuration.ProductConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProductDisplayModel, Interop.API.Common.Models.Display.ProductDisplayModel, Models.Page.Configuration.ProductConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.ProductDisplayModel> configurationSuccessAction, Models.Page.Configuration.ProductConfigurationPageModel model)
        {
            return new Pages.Configuration.ProductConfigurationPage(configurationSuccessAction, model);
        }
    }
}
