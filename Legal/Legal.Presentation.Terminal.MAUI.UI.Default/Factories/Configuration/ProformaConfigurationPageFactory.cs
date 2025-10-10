namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ProformaConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProformaDisplayModel, Models.Page.Configuration.ProformaConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProformaDisplayModel, Interop.API.Common.Models.Display.ProformaDisplayModel, Models.Page.Configuration.ProformaConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProformaDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProformaDisplayModel model)
        {
            return new Pages.Configuration.ProformaConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ProformaConfigurationPageModel(model));
        }
    }
}
