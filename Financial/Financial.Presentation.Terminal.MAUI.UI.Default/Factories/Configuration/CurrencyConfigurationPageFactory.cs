namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class CurrencyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.CurrencyDisplayModel, Models.Page.Configuration.CurrencyConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.CurrencyDisplayModel, Interop.API.Common.Models.Display.CurrencyDisplayModel, Models.Page.Configuration.CurrencyConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.CurrencyDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.CurrencyDisplayModel model)
        {
            return new Pages.Configuration.CurrencyConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.CurrencyConfigurationPageModel(model), new Validators.CurrencyConfigurationValidator());
        }
    }
}
