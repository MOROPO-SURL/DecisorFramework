using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ProductConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductDisplayModel, Models.Page.Configuration.ProductConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProductDisplayModel, Interop.API.Common.Models.Display.ProductDisplayModel, Models.Page.Configuration.ProductConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProductDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProductDisplayModel model)
        {
            var _model = new Models.Page.Configuration.ProductConfigurationPageModel(model);

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientHelperProvider);
            var familiesAPIConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(httpClientHelperProvider);

            // TODO complete fallow behavior
            //var warehousingDecreasesAPIConnectClient = new Web.API.Connect.Clients.WarehousingDecreasesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

            _model.AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync();
            _model.AvailableCategories = await familiesAPIConnectClient.GetAsync();

            return new Pages.Configuration.ProductConfigurationPage(configurationSuccessAction, _model);
        }
    }
}
