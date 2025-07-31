namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ProductionOrderConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Models.Page.Configuration.ProductionOrderConfigurationPageModel, Pages.Configuration.ProductionOrderConfigurationPage>
    {
        public Pages.Configuration.ProductionOrderConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.ProductionOrderDisplayModel> configurationSuccessAction, Models.Page.Configuration.ProductionOrderConfigurationPageModel model)
        {
            return new Pages.Configuration.ProductionOrderConfigurationPage(configurationSuccessAction, model);
        }
    }
}
