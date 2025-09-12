namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class NaturalClientConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientDisplayModel, Models.Page.Configuration.NaturalClientConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientDisplayModel, Interop.API.Common.Models.Display.NaturalClientDisplayModel, Models.Page.Configuration.NaturalClientConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.NaturalClientDisplayModel> configurationSuccessAction, Models.Page.Configuration.NaturalClientConfigurationPageModel model)
        {
            return new Pages.Configuration.NaturalClientConfigurationPage(configurationSuccessAction, model);
        }
    }
}