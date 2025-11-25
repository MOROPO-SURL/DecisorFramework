namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class NaturalClientSampleAnalysisServiceOrderConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel, Models.Page.Configuration.NaturalClientSampleAnalysisServiceOrderConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel, Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel, Models.Page.Configuration.NaturalClientSampleAnalysisServiceOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel model)
    {
        return new Pages.Configuration.NaturalClientSampleAnalysisServiceOrderConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.NaturalClientSampleAnalysisServiceOrderConfigurationPageModel(model), new Validators.NaturalClientSampleAnalysisServiceOrderConfigurationValidator());
    }
}