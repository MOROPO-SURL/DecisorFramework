namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class AdmitionPropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel, Models.Page.Configuration.AdmitionPropousalConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel, Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel, Models.Page.Configuration.AdmitionPropousalConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel> configurationSuccessAction, Models.Page.Configuration.AdmitionPropousalConfigurationPageModel model)
        {
            return new Pages.Configuration.AdmitionPropousalConfigurationPage(configurationSuccessAction, model);
        }
    }
}