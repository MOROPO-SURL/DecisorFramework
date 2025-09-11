namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class OcupationCandidateConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel, Models.Page.Configuration.OcupationCandidateConfigurationPageModel, Pages.Configuration.OcupationCandidateConfigurationPage>
    {
        public Pages.Configuration.OcupationCandidateConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel> configurationSuccessAction, Models.Page.Configuration.OcupationCandidateConfigurationPageModel model)
        {
            return new Pages.Configuration.OcupationCandidateConfigurationPage(configurationSuccessAction, model);
        }
    }
}