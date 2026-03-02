using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VehicleConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleDisplayModel, Models.Page.Configuration.VehicleConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.VehicleDisplayModel, Interop.API.Common.Models.Display.VehicleDisplayModel, Models.Page.Configuration.VehicleConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.VehicleDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.VehicleDisplayModel model)
        {
            var _model = new Models.Page.Configuration.VehicleConfigurationPageModel(model);

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var brandsAPIConnectClient = new Interop.API.Connect.Clients.BrandsAPIConnectClient(httpClientHelperProvider);
            var kindsAPIConnectClient = new Interop.API.Connect.Clients.VehicleKindsAPIConnectClient(httpClientHelperProvider);
            var engineKindsAPIConnectClient = new Interop.API.Connect.Clients.VehicleEngineKindsAPIConnectClient(httpClientHelperProvider);
            var structuresAPIConnectClient = new Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(httpClientHelperProvider);

            _model.AvailableBrands = await brandsAPIConnectClient.GetAsync();
            _model.AvailableKinds = await kindsAPIConnectClient.GetEnabledAsync();
            _model.AvailableEngineKinds = await engineKindsAPIConnectClient.GetEnabledAsync();
            _model.AvailableStructures = await structuresAPIConnectClient.GetEnabledAsync();

            return new Pages.Configuration.VehicleConfigurationPage(configurationSuccessAction, _model, new Validators.VehicleConfigurationValidator());
        }
    }
}