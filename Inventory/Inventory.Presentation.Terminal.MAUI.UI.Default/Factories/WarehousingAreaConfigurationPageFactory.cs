namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class WarehousingAreaConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Models.Page.Configuration.WarehousingAreaConfigurationPageModel, Pages.Configuration.WarehousingAreaConfigurationPage>
    {
        public Pages.Configuration.WarehousingAreaConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel> configurationSuccessAction, Models.Page.Configuration.WarehousingAreaConfigurationPageModel model)
        {
            return new Pages.Configuration.WarehousingAreaConfigurationPage(configurationSuccessAction, model);
        }
    }
}
