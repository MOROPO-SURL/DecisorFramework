namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class LegalClientSampleAnalysisServiceExecutionConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel, Models.Page.Configuration.LegalClientSampleAnalysisServiceExecutionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel, Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel, Models.Page.Configuration.LegalClientSampleAnalysisServiceExecutionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel model)
    {
        return new Pages.Configuration.LegalClientSampleAnalysisServiceExecutionConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.LegalClientSampleAnalysisServiceExecutionConfigurationPageModel(model), new Validators.LegalClientSampleAnalysisServiceExecutionConfigurationValidator());
    }
}