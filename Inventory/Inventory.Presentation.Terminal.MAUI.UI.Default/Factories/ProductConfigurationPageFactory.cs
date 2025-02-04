namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class ProductConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductDisplayModel, Models.Page.Configuration.ProductConfigurationPageModel, Pages.Configuration.ProductConfigurationPage>
    {
        public Pages.Configuration.ProductConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.ProductDisplayModel> configurationSuccessAction, Models.Page.Configuration.ProductConfigurationPageModel model)
        {
            return new Pages.Configuration.ProductConfigurationPage(configurationSuccessAction, model);
        }
    }
}
