namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class GuidelineConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.GuidelineDisplayModel, Models.Page.Configuration.GuidelineConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.GuidelineDisplayModel, Interop.API.Common.Models.Display.GuidelineDisplayModel, Models.Page.Configuration.GuidelineConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.GuidelineDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.GuidelineDisplayModel model)
        {
            return new UI.Pages.Configuration.GuidelineConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.GuidelineConfigurationPageModel(model));
        }
    }
}