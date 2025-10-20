namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ParticipatingOrganizationConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel, Models.Page.Configuration.ParticipatingOrganizationConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel, Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel, Models.Page.Configuration.ParticipatingOrganizationConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel model)
        {
            return new Pages.Configuration.ParticipatingOrganizationConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ParticipatingOrganizationConfigurationPageModel(model), new Validators.ParticipatingOrganizationConfigurationValidator());
        }
    }
}
