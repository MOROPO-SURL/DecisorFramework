namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class CallForProposalConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.CallForProposalDisplayModel, Models.Page.Configuration.CallForProposalConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.CallForProposalDisplayModel, Interop.API.Common.Models.Display.CallForProposalDisplayModel, Models.Page.Configuration.CallForProposalConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.CallForProposalDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.CallForProposalDisplayModel model)
    {
        return new Pages.Configuration.CallForProposalConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.CallForProposalConfigurationPageModel(model), new Validators.CallForProposalConfigurationValidator());
    }
}