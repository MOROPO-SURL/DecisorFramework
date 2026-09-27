namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class LegalClientTrainingServiceExecutionConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel, Models.Page.Configuration.LegalClientTrainingServiceExecutionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel, Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel, Models.Page.Configuration.LegalClientTrainingServiceExecutionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel model)
    {
        return new Pages.Configuration.LegalClientTrainingServiceExecutionConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.LegalClientTrainingServiceExecutionConfigurationPageModel(model), new Validators.LegalClientTrainingServiceExecutionConfigurationValidator());
    }
}