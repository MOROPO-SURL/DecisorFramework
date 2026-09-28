namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ThesisResultConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ThesisResultDisplayModel, Models.Page.Configuration.ThesisResultConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ThesisResultDisplayModel, Interop.API.Common.Models.Display.ThesisResultDisplayModel, Models.Page.Configuration.ThesisResultConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ThesisResultDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ThesisResultDisplayModel model)
    {
        return new Pages.Configuration.ThesisResultConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ThesisResultConfigurationPageModel(model), new Validators.ThesisResultConfigurationValidator());
    }
}