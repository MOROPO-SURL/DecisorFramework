namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class AdmitionPropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel, Models.Page.Configuration.AdmitionPropousalConfigurationPageModel, Pages.Configuration.AdmitionPropousalConfigurationPage>
    {
        public Pages.Configuration.AdmitionPropousalConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel> configurationSuccessAction, Models.Page.Configuration.AdmitionPropousalConfigurationPageModel model)
        {
            return new Pages.Configuration.AdmitionPropousalConfigurationPage(configurationSuccessAction, model);
        }
    }
}