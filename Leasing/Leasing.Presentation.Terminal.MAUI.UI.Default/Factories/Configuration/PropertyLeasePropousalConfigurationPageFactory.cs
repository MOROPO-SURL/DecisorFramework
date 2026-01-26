using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class PropertyLeasePropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel model)
    {
        var _model = new Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel(model);

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var apiConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(httpClientHelperProvider);

        _model.AvailableCurrencies = await apiConnectClient.GetAsync();

        return new Pages.Configuration.PropertyLeasePropousalConfigurationPage(configurationSuccessAction, _model, new Validators.PropertyLeasePropousalConfigurationValidator());
    }
}
