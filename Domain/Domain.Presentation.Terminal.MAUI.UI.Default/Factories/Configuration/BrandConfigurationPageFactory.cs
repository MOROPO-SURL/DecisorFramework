namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class BrandConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.BrandDisplayModel, Models.Page.Configuration.BrandConfigurationPageModel, Pages.Configuration.BrandConfigurationPage>
    {
        public Pages.Configuration.BrandConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.BrandDisplayModel> configurationSuccessAction, Models.Page.Configuration.BrandConfigurationPageModel model)
        {
            return new Pages.Configuration.BrandConfigurationPage(configurationSuccessAction, model);
        }
    }
}
