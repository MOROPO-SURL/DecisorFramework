namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class PersonConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PersonDisplayModel, Models.Page.Configuration.PersonConfigurationPageModel, UI.Pages.Configuration.PersonConfigurationPage>
    {
        public UI.Pages.Configuration.PersonConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.PersonDisplayModel> configurationSuccessAction, Models.Page.Configuration.PersonConfigurationPageModel model)
        {
            return new UI.Pages.Configuration.PersonConfigurationPage(configurationSuccessAction, model);
        }
    }
}