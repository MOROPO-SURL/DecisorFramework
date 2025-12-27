namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class FinancierConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.FinancierDisplayModel, Models.Page.Configuration.FinancierConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.FinancierDisplayModel, Interop.API.Common.Models.Display.FinancierDisplayModel, Models.Page.Configuration.FinancierConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.FinancierDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.FinancierDisplayModel model)
    {
        return new Pages.Configuration.FinancierConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.FinancierConfigurationPageModel(model), new Validators.FinancierConfigurationValidator());
    }
}
