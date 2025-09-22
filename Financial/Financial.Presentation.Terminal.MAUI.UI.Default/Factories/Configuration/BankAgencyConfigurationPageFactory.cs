namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class BankAgencyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.BankAgencyDisplayModel, Models.Page.Configuration.BankAgencyConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.BankAgencyDisplayModel, Interop.API.Common.Models.Display.BankAgencyDisplayModel, Models.Page.Configuration.BankAgencyConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.BankAgencyDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.BankAgencyDisplayModel model)
        {
            return new Pages.Configuration.BankAgencyConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.BankAgencyConfigurationPageModel(model), new Validators.BankAgencyConfigurationValidator());
        }
    }
}
