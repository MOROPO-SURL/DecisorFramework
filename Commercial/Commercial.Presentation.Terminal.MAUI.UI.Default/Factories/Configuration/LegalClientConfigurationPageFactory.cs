namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class LegalClientConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientDisplayModel, Models.Page.Configuration.LegalClientConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientDisplayModel, Interop.API.Common.Models.Display.LegalClientDisplayModel, Models.Page.Configuration.LegalClientConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.LegalClientDisplayModel> configurationSuccessAction, Models.Page.Configuration.LegalClientConfigurationPageModel model)
        {
            return new Pages.Configuration.LegalClientConfigurationPage(configurationSuccessAction, model, new Validators.LegalClientConfigurationValidator());
        }
    }
}
