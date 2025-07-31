namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class BankAgencyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.BankAgencyDisplayModel, Models.Page.Configuration.BankAgencyConfigurationPageModel, Pages.Configuration.BankAgencyConfigurationPage>
    {
        public Pages.Configuration.BankAgencyConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.BankAgencyDisplayModel> configurationSuccessAction, Models.Page.Configuration.BankAgencyConfigurationPageModel model)
        {
            return new Pages.Configuration.BankAgencyConfigurationPage(configurationSuccessAction, model);
        }
    }
}
