namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class AnalysisQualityCheckConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel, Models.Page.Configuration.AnalysisQualityCheckConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel, Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel, Models.Page.Configuration.AnalysisQualityCheckConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel model)
    {
        return new Pages.Configuration.AnalysisQualityCheckConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.AnalysisQualityCheckConfigurationPageModel(model), new Validators.AnalysisQualityCheckConfigurationValidator());
    }
}