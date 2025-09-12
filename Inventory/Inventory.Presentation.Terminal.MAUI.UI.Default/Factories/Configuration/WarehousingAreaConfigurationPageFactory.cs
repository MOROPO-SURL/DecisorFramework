namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class WarehousingAreaConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Models.Page.Configuration.WarehousingAreaConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Models.Page.Configuration.WarehousingAreaConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel> configurationSuccessAction, Models.Page.Configuration.WarehousingAreaConfigurationPageModel model)
        {
            return new Pages.Configuration.WarehousingAreaConfigurationPage(configurationSuccessAction, model);
        }
    }
}
