namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class LegalClientSampleAnalysisServiceOrderConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, Models.Page.Configuration.LegalClientSampleAnalysisServiceOrderConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, Models.Page.Configuration.LegalClientSampleAnalysisServiceOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel model)
    {
        return new Pages.Configuration.LegalClientSampleAnalysisServiceOrderConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.LegalClientSampleAnalysisServiceOrderConfigurationPageModel(model), new Validators.LegalClientSampleAnalysisServiceOrderConfigurationValidator());
    }
}