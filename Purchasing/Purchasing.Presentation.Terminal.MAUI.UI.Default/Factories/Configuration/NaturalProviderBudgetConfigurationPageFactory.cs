namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class NaturalProviderBudgetConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel, Models.Page.Configuration.NaturalProviderBudgetConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel, Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel, Models.Page.Configuration.NaturalProviderBudgetConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel model)
        {
            return new Pages.Configuration.NaturalProviderBudgetConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.NaturalProviderBudgetConfigurationPageModel(model), new Validators.NaturalProviderBudgetConfigurationValidator());
        }
    }
}