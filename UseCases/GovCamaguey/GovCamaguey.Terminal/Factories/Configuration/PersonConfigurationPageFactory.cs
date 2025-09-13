namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class PersonConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PersonDisplayModel, Models.Page.Configuration.PersonConfigurationPageModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PersonDisplayModel, Interop.API.Common.Models.Display.PersonDisplayModel, Models.Page.Configuration.PersonConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.PersonDisplayModel> configurationSuccessAction, Models.Page.Configuration.PersonConfigurationPageModel model)
        {
            return new UI.Pages.Configuration.PersonConfigurationPage(configurationSuccessAction, model);
        }
    }
}