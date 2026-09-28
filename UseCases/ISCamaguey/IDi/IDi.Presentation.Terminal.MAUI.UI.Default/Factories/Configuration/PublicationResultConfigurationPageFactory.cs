namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class PublicationResultConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PublicationResultDisplayModel, Models.Page.Configuration.PublicationResultConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PublicationResultDisplayModel, Interop.API.Common.Models.Display.PublicationResultDisplayModel, Models.Page.Configuration.PublicationResultConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PublicationResultDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PublicationResultDisplayModel model)
    {
        return new Pages.Configuration.PublicationResultConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.PublicationResultConfigurationPageModel(model), new Validators.PublicationResultConfigurationValidator());
    }
}