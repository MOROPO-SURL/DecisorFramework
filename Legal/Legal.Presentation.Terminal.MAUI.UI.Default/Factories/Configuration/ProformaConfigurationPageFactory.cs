namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ProformaConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProformaDisplayModel, Models.Page.Configuration.ProformaConfigurationPageModel, Pages.Configuration.ProformaConfigurationPage>
    {
        public Pages.Configuration.ProformaConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.ProformaDisplayModel> configurationSuccessAction, Models.Page.Configuration.ProformaConfigurationPageModel model)
        {
            return new Pages.Configuration.ProformaConfigurationPage(configurationSuccessAction, model);
        }
    }
}
