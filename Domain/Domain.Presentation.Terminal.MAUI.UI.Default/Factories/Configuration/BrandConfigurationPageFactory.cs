namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class BrandConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.BrandDisplayModel, Models.Page.Configuration.BrandConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.BrandDisplayModel, Interop.API.Common.Models.Display.BrandDisplayModel, Models.Page.Configuration.BrandConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.BrandDisplayModel> configurationSuccessAction, Models.Page.Configuration.BrandConfigurationPageModel model)
        {
            return new Pages.Configuration.BrandConfigurationPage(configurationSuccessAction, model);
        }
    }
}
