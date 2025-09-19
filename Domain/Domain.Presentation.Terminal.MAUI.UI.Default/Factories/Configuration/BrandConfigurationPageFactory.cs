namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class BrandConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.BrandDisplayModel, Models.Page.Configuration.BrandConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.BrandDisplayModel, Interop.API.Common.Models.Display.BrandDisplayModel, Models.Page.Configuration.BrandConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.BrandDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.BrandDisplayModel model)
        {
            return new Pages.Configuration.BrandConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.BrandConfigurationPageModel(model));
        }
    }
}
