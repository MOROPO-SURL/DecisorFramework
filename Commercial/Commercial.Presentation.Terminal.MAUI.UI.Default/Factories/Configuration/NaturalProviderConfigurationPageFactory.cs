namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class NaturalProviderConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Models.Page.Configuration.NaturalProviderConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Models.Page.Configuration.NaturalProviderConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> configurationSuccessAction, Models.Page.Configuration.NaturalProviderConfigurationPageModel model)
        {
            return new Pages.Configuration.NaturalProviderConfigurationPage(configurationSuccessAction, model);
        }
    }
}
