namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class LegalProviderBudgetConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel, Models.Page.Configuration.LegalProviderBudgetConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel, Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel, Models.Page.Configuration.LegalProviderBudgetConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel model)
        {
            return new Pages.Configuration.LegalProviderBudgetConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.LegalProviderBudgetConfigurationPageModel(model), new Validators.LegalProviderBudgetConfigurationValidator());
        }
    }
}
