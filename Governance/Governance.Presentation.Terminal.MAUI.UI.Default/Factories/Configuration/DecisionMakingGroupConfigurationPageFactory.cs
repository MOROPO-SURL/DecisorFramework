namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class DecisionMakingGroupConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> configurationSuccessAction, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel model)
        {
            return new Pages.Configuration.DecisionMakingGroupConfigurationPage(configurationSuccessAction, model);
        }
    }
}