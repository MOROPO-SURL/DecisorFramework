namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PropertyLeaseOfferConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel, Pages.Configuration.PropertyLeaseOfferConfigurationPage>
    {
        public Pages.Configuration.PropertyLeaseOfferConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel> configurationSuccessAction, Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel model)
        {
            return new Pages.Configuration.PropertyLeaseOfferConfigurationPage(configurationSuccessAction, model);
        }
    }
}
