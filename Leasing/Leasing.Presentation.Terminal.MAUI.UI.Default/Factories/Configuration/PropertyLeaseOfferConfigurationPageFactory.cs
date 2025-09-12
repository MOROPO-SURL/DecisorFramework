namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PropertyLeaseOfferConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel> configurationSuccessAction, Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel model)
        {
            return new Pages.Configuration.PropertyLeaseOfferConfigurationPage(configurationSuccessAction, model);
        }
    }
}
