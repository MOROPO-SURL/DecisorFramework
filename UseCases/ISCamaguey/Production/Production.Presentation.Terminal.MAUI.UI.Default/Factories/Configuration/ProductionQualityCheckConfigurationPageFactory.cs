namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ProductionQualityCheckConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel, Models.Page.Configuration.ProductionQualityCheckConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel, Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel, Models.Page.Configuration.ProductionQualityCheckConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel model)
    {
        return new Pages.Configuration.ProductionQualityCheckConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ProductionQualityCheckConfigurationPageModel(model), new Validators.ProductionQualityCheckConfigurationValidator());
    }
}