using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VehicleLeaseOfferConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel model)
        {
            var _model = new Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel(model);

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var apiConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(httpClientHelperProvider);

            _model.AvailableCurrencies = await apiConnectClient.GetAsync();

            return new Pages.Configuration.VehicleLeaseOfferConfigurationPage(configurationSuccessAction, _model, new Validators.VehicleLeaseOfferConfigurationValidator());
        }
    }
}