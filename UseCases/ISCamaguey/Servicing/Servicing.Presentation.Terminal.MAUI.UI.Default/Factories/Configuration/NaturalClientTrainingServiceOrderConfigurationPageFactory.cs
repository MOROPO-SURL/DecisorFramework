
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class NaturalClientTrainingServiceOrderConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel, Models.Page.Configuration.NaturalClientTrainingServiceOrderConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel, Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel, Models.Page.Configuration.NaturalClientTrainingServiceOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel model)
        {
            return new Pages.Configuration.NaturalClientTrainingServiceOrderConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.NaturalClientTrainingServiceOrderConfigurationPageModel(model), new Validators.NaturalClientTrainingServiceOrderConfigurationValidator());
        }
    }
}
