namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class WarehousingAreaConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Models.Page.Configuration.WarehousingAreaConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Models.Page.Configuration.WarehousingAreaConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.WarehousingAreaDisplayModel model)
        {
            return new Pages.Configuration.WarehousingAreaConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.WarehousingAreaConfigurationPageModel(model));
        }
    }
}
