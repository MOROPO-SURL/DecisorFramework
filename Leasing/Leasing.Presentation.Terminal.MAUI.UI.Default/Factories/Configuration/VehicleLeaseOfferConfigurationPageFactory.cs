namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VehicleLeaseOfferConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel, Pages.Configuration.VehicleLeaseOfferConfigurationPage>
    {
        public Pages.Configuration.VehicleLeaseOfferConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel> configurationSuccessAction, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel model)
        {
            return new Pages.Configuration.VehicleLeaseOfferConfigurationPage(configurationSuccessAction, model);
        }
    }
}