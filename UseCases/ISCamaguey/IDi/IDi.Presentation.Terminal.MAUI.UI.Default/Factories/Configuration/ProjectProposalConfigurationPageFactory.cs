namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ProjectProposalConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProjectProposalDisplayModel, Models.Page.Configuration.ProjectProposalConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProjectProposalDisplayModel, Interop.API.Common.Models.Display.ProjectProposalDisplayModel, Models.Page.Configuration.ProjectProposalConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProjectProposalDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProjectProposalDisplayModel model)
    {
        return new Pages.Configuration.ProjectProposalConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ProjectProposalConfigurationPageModel(model), new Validators.ProjectProposalConfigurationValidator());
    }
}