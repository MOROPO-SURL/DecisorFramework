namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class DecisionMakingGroupConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel, Pages.Configuration.DecisionMakingGroupConfigurationPage>
    {
        public Pages.Configuration.DecisionMakingGroupConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> configurationSuccessAction, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel model)
        {
            return new Pages.Configuration.DecisionMakingGroupConfigurationPage(configurationSuccessAction, model);
        }
    }
}