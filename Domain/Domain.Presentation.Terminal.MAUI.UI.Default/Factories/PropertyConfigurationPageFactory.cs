namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class PropertyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyDisplayModel, Models.Page.Configuration.PropertyConfigurationPageModel, Pages.Configuration.PropertyConfigurationPage>
    {
        public Pages.Configuration.PropertyConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel> configurationSuccessAction, Models.Page.Configuration.PropertyConfigurationPageModel model)
        {
            return new Pages.Configuration.PropertyConfigurationPage(configurationSuccessAction, model);
        }
    }
}
