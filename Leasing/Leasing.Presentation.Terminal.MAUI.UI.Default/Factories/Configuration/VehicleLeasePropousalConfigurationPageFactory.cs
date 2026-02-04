using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class VehicleLeasePropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel model)
    {
        var _model = new Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel(model);

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var apiConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(httpClientHelperProvider);

        _model.AvailableCurrencies = await apiConnectClient.GetAsync();

        return new Pages.Configuration.VehicleLeasePropousalConfigurationPage(configurationSuccessAction, _model, new Validators.VehicleLeasePropousalConfigurationValidator());
    }
}