
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class LegalClientGroundIntegralStudyServiceOrderConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, Models.Page.Configuration.LegalClientGroundIntegralStudyServiceOrderConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, Models.Page.Configuration.LegalClientGroundIntegralStudyServiceOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel model)
        {
            return new Pages.Configuration.LegalClientGroundIntegralStudyServiceOrderConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.LegalClientGroundIntegralStudyServiceOrderConfigurationPageModel(model), new Validators.LegalClientGroundIntegralStudyServiceOrderConfigurationValidator());
        }
    }
}
