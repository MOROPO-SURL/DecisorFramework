namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class TrainingServiceConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.TrainingServiceDisplayModel, Models.Page.Configuration.TrainingServiceConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.TrainingServiceDisplayModel, Interop.API.Common.Models.Display.TrainingServiceDisplayModel, Models.Page.Configuration.TrainingServiceConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.TrainingServiceDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.TrainingServiceDisplayModel model)
    {
        return new Pages.Configuration.TrainingServiceConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.TrainingServiceConfigurationPageModel(model), new Validators.TrainingServiceConfigurationValidator());
    }
}
