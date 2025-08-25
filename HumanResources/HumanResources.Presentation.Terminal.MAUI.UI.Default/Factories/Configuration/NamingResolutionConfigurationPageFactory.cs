namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class NamingResolutionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Models.Page.Configuration.NamingResolutionConfigurationPageModel, Pages.Configuration.NamingResolutionConfigurationPage>
    {
        public Pages.Configuration.NamingResolutionConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> configurationSuccessAction, Models.Page.Configuration.NamingResolutionConfigurationPageModel model)
        {
            return new Pages.Configuration.NamingResolutionConfigurationPage(configurationSuccessAction, model);
        }
    }
}