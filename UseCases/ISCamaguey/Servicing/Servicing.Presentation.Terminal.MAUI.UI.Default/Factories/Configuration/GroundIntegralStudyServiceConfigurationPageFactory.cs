namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class GroundIntegralStudyServiceConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel, Models.Page.Configuration.GroundIntegralStudyServiceConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel, Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel, Models.Page.Configuration.GroundIntegralStudyServiceConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel model)
        {
            return new Pages.Configuration.GroundIntegralStudyServiceConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.GroundIntegralStudyServiceConfigurationPageModel(model), new Validators.GroundIntegralStudyServiceConfigurationValidator());
        }
    }
}