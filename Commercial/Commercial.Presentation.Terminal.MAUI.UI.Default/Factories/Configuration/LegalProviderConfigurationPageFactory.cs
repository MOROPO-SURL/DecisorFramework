namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class LegalProviderConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalProviderDisplayModel, Models.Page.Configuration.LegalProviderConfigurationPageModel, Pages.Configuration.LegalProviderConfigurationPage>
    {
        public Pages.Configuration.LegalProviderConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.LegalProviderDisplayModel> configurationSuccessAction, Models.Page.Configuration.LegalProviderConfigurationPageModel model)
        {
            return new Pages.Configuration.LegalProviderConfigurationPage(configurationSuccessAction, model);
        }
    }
}