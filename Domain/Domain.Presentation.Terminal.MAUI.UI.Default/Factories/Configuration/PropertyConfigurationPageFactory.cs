namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PropertyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyDisplayModel, Models.Page.Configuration.PropertyConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PropertyDisplayModel, Interop.API.Common.Models.Display.PropertyDisplayModel, Models.Page.Configuration.PropertyConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel> configurationSuccessAction, Models.Page.Configuration.PropertyConfigurationPageModel model)
        {
            return new Pages.Configuration.PropertyConfigurationPage(configurationSuccessAction, model);
        }
    }
}
