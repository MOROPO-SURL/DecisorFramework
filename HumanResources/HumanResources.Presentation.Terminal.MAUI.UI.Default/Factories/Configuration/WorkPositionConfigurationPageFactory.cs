namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class WorkPositionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkPositionDisplayModel, Models.Page.Configuration.WorkPositionConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WorkPositionDisplayModel, Interop.API.Common.Models.Display.WorkPositionDisplayModel, Models.Page.Configuration.WorkPositionConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.WorkPositionDisplayModel> configurationSuccessAction, Models.Page.Configuration.WorkPositionConfigurationPageModel model)
        {
            return new Pages.Configuration.WorkPositionConfigurationPage(configurationSuccessAction, model);
        }
    }
}
