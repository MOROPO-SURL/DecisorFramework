namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ScientificTechnicalResultIntroductionConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel, Models.Page.Configuration.ScientificTechnicalResultIntroductionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel, Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel, Models.Page.Configuration.ScientificTechnicalResultIntroductionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel model)
    {
        return new Pages.Configuration.ScientificTechnicalResultIntroductionConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ScientificTechnicalResultIntroductionConfigurationPageModel(model), new Validators.ScientificTechnicalResultIntroductionConfigurationValidator());
    }
}