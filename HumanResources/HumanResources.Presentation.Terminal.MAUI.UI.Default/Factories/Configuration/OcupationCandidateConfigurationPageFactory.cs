namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class OcupationCandidateConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel, Models.Page.Configuration.OcupationCandidateConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel, Interop.API.Common.Models.Display.OcupationCandidateDisplayModel, Models.Page.Configuration.OcupationCandidateConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.OcupationCandidateDisplayModel model)
    {
        return new Pages.Configuration.OcupationCandidateConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.OcupationCandidateConfigurationPageModel(model), new Validators.OcupationCandidateConfigurationValidator());
    }
}