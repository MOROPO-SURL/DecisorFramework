namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class ObjectiveConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ObjectiveDisplayModel, Models.Page.Configuration.ObjectiveConfigurationPageModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ObjectiveDisplayModel, Interop.API.Common.Models.Display.ObjectiveDisplayModel, Models.Page.Configuration.ObjectiveConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.ObjectiveDisplayModel> configurationSuccessAction, Models.Page.Configuration.ObjectiveConfigurationPageModel model)
        {
            return new UI.Pages.Configuration.ObjectiveConfigurationPage(configurationSuccessAction, model);
        }
    }
}
