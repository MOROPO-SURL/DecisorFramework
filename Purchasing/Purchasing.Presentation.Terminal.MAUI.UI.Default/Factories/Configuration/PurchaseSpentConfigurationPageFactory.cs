namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PurchaseSpentConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel, Models.Page.Configuration.PurchaseSpentConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel, Interop.API.Common.Models.Display.PurchaseSpentDisplayModel, Models.Page.Configuration.PurchaseSpentConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PurchaseSpentDisplayModel model)
        {
            return new Pages.Configuration.PurchaseSpentConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.PurchaseSpentConfigurationPageModel(model), new Validators.PurchaseSpentConfigurationValidator());
        }
    }
}