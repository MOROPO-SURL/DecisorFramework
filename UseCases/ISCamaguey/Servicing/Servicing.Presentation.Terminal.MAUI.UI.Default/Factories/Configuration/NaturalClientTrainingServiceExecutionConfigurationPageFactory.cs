namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class NaturalClientTrainingServiceExecutionConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel, Models.Page.Configuration.NaturalClientTrainingServiceExecutionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel, Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel, Models.Page.Configuration.NaturalClientTrainingServiceExecutionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel model)
    {
        return new Pages.Configuration.NaturalClientTrainingServiceExecutionConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.NaturalClientTrainingServiceExecutionConfigurationPageModel(model), new Validators.NaturalClientTrainingServiceExecutionConfigurationValidator());
    }
}