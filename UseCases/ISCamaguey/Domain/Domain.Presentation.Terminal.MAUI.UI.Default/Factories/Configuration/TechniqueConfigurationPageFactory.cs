namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class TechniqueConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.TechniqueDisplayModel, Models.Page.Configuration.TechniqueConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.TechniqueDisplayModel, Interop.API.Common.Models.Display.TechniqueDisplayModel, Models.Page.Configuration.TechniqueConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.TechniqueDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.TechniqueDisplayModel model)
        {
            return new Pages.Configuration.TechniqueConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.TechniqueConfigurationPageModel(model), new Validators.TechniqueConfigurationValidator());
        }
    }
}