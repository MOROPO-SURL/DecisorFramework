
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class LegalClientTrainingServiceOrderConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel, Models.Page.Configuration.LegalClientTrainingServiceOrderConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel, Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel, Models.Page.Configuration.LegalClientTrainingServiceOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel model)
        {
            return new Pages.Configuration.LegalClientTrainingServiceOrderConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.LegalClientTrainingServiceOrderConfigurationPageModel(model), new Validators.LegalClientTrainingServiceOrderConfigurationValidator());
        }
    }
}
