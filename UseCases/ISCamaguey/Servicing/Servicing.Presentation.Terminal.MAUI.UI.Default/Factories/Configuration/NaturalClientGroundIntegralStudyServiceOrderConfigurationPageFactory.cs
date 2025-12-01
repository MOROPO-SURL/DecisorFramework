
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class NaturalClientGroundIntegralStudyServiceOrderConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, Models.Page.Configuration.NaturalClientGroundIntegralStudyServiceOrderConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, Models.Page.Configuration.NaturalClientGroundIntegralStudyServiceOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel model)
        {
            return new Pages.Configuration.NaturalClientGroundIntegralStudyServiceOrderConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.NaturalClientGroundIntegralStudyServiceOrderConfigurationPageModel(model), new Validators.NaturalClientGroundIntegralStudyServiceOrderConfigurationValidator());
        }
    }
}
