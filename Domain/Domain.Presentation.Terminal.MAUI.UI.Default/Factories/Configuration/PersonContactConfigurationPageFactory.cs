namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PersonContactConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PersonContactDisplayModel, Models.Page.Configuration.PersonContactConfigurationPageModel, Pages.Configuration.PersonContactConfigurationPage>
    {
        public Pages.Configuration.PersonContactConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.PersonContactDisplayModel> configurationSuccessAction, Models.Page.Configuration.PersonContactConfigurationPageModel model)
        {
            return new Pages.Configuration.PersonContactConfigurationPage(configurationSuccessAction, model);
        }
    }
}
