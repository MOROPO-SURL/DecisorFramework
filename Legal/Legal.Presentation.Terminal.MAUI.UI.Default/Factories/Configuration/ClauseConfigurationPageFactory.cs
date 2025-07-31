namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ClauseConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ClauseDisplayModel, Models.Page.Configuration.ClauseConfigurationPageModel, Pages.Configuration.ClauseConfigurationPage>
    {
        public Pages.Configuration.ClauseConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.ClauseDisplayModel> configurationSuccessAction, Models.Page.Configuration.ClauseConfigurationPageModel model)
        {
            return new Pages.Configuration.ClauseConfigurationPage(configurationSuccessAction, model);
        }
    }
}
