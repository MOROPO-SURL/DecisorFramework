using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PurchaseOrderConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel, Models.Page.Configuration.PurchaseOrderConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel, Interop.API.Common.Models.Display.PurchaseOrderDisplayModel, Models.Page.Configuration.PurchaseOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PurchaseOrderDisplayModel model)
        {
            var _model = new Models.Page.Configuration.PurchaseOrderConfigurationPageModel(model);

            var httpClientProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var zonesAPIConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(httpClientProvider);
            var currenciesAPIConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(httpClientProvider);

            _model.AvailableZones = await zonesAPIConnectClient.GetAsync();
            _model.AvailableCurrencies = await currenciesAPIConnectClient.GetAsync();

            return new Pages.Configuration.PurchaseOrderConfigurationPage(configurationSuccessAction, _model, new Validators.PurchaseOrderConfigurationValidator());
        }
    }
}
