namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PurchaseRequestConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel, Models.Page.Configuration.PurchaseRequestConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel, Interop.API.Common.Models.Display.PurchaseRequestDisplayModel, Models.Page.Configuration.PurchaseRequestConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PurchaseRequestDisplayModel model)
        {
            return new Pages.Configuration.PurchaseRequestConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.PurchaseRequestConfigurationPageModel(model), new Validators.PurchaseRequestConfigurationValidator());
        }
    }
}
