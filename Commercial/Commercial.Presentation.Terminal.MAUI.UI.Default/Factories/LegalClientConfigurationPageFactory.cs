namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class LegalClientConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientDisplayModel, Models.Page.Configuration.LegalClientConfigurationPageModel, Pages.Configuration.LegalClientConfigurationPage>
    {
        public Pages.Configuration.LegalClientConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.LegalClientDisplayModel> configurationSuccessAction, Models.Page.Configuration.LegalClientConfigurationPageModel model)
        {
            return new Pages.Configuration.LegalClientConfigurationPage(configurationSuccessAction, model);
        }
    }
}
