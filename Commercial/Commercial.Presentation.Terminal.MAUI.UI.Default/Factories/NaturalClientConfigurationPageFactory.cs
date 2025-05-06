namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class NaturalClientConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientDisplayModel, Models.Page.Configuration.NaturalClientConfigurationPageModel, Pages.Configuration.NaturalClientConfigurationPage>
    {
        public Pages.Configuration.NaturalClientConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.NaturalClientDisplayModel> configurationSuccessAction, Models.Page.Configuration.NaturalClientConfigurationPageModel model)
        {
            return new Pages.Configuration.NaturalClientConfigurationPage(configurationSuccessAction, model);
        }
    }
}