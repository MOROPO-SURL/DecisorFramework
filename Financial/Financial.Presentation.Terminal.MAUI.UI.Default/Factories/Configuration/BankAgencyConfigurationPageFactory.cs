namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class BankAgencyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.BankAgencyDisplayModel, Models.Page.Configuration.BankAgencyConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.BankAgencyDisplayModel, Interop.API.Common.Models.Display.BankAgencyDisplayModel, Models.Page.Configuration.BankAgencyConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.BankAgencyDisplayModel> configurationSuccessAction, Models.Page.Configuration.BankAgencyConfigurationPageModel model)
        {
            return new Pages.Configuration.BankAgencyConfigurationPage(configurationSuccessAction, model);
        }
    }
}
