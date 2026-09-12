using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

internal sealed class AssessmentConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Models.View.AssessmentDetailViewModel, Models.Page.Configuration.AssessmentConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Models.View.AssessmentDetailViewModel, Models.View.AssessmentDetailViewModel, Models.Page.Configuration.AssessmentConfigurationPageModel>> BuildAsync(System.Action<Models.View.AssessmentDetailViewModel> configurationSuccessAction, Models.View.AssessmentDetailViewModel model)
    {
        Models.Page.Configuration.AssessmentConfigurationPageModel _model = new(model);

        return new Pages.Configuration.AssessmentConfigurationPage(configurationSuccessAction, _model, new Validators.AssessmentConfigurationValidator());
    }
}