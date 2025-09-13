namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class GuidelineConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.GuidelineDisplayModel, Models.Page.Configuration.GuidelineConfigurationPageModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.GuidelineDisplayModel, Interop.API.Common.Models.Display.GuidelineDisplayModel, Models.Page.Configuration.GuidelineConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.GuidelineDisplayModel> configurationSuccessAction, Models.Page.Configuration.GuidelineConfigurationPageModel model)
        {
            return new UI.Pages.Configuration.GuidelineConfigurationPage(configurationSuccessAction, model);
        }
    }
}