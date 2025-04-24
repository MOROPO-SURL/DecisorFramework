namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class ObjectiveConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ObjectiveDisplayModel, Models.Page.Configuration.ObjectiveConfigurationPageModel, UI.Pages.Configuration.ObjectiveConfigurationPage>
    {
        public UI.Pages.Configuration.ObjectiveConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.ObjectiveDisplayModel> configurationSuccessAction, Models.Page.Configuration.ObjectiveConfigurationPageModel model)
        {
            return new UI.Pages.Configuration.ObjectiveConfigurationPage(configurationSuccessAction, model);
        }
    }
}
