namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ProductionOrderConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Models.Page.Configuration.ProductionOrderConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Models.Page.Configuration.ProductionOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProductionOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProductionOrderDisplayModel model)
    {
        return new Pages.Configuration.ProductionOrderConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ProductionOrderConfigurationPageModel(model), new Validators.ProductionOrderConfigurationValidator());
    }
}