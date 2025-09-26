namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ClauseConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ClauseDisplayModel, Models.Page.Configuration.ClauseConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ClauseDisplayModel, Interop.API.Common.Models.Display.ClauseDisplayModel, Models.Page.Configuration.ClauseConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ClauseDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ClauseDisplayModel model)
        {
            return new Pages.Configuration.ClauseConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ClauseConfigurationPageModel(model));
        }
    }
}
