namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class WarehouseConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WarehouseDisplayModel, Models.Page.Configuration.WarehouseConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WarehouseDisplayModel, Interop.API.Common.Models.Display.WarehouseDisplayModel, Models.Page.Configuration.WarehouseConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.WarehouseDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.WarehouseDisplayModel model)
        {
            return new Pages.Configuration.WarehouseConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.WarehouseConfigurationPageModel(model));
        }
    }
}