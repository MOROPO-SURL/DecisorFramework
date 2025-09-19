namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VehicleLeaseOfferConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel model)
        {
            return new Pages.Configuration.VehicleLeaseOfferConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel(model));
        }
    }
}