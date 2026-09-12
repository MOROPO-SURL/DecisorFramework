namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class AssessmentQualityCheckConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel, Models.Page.Configuration.AssessmentQualityCheckConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel, Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel, Models.Page.Configuration.AssessmentQualityCheckConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel model)
    {
        return new Pages.Configuration.AssessmentQualityCheckConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.AssessmentQualityCheckConfigurationPageModel(model), new Validators.AssessmentQualityCheckConfigurationValidator());
    }
}