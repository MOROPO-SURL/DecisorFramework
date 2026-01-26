using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class PropertyLeaseOfferConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel model)
    {
        var _model = new Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel(model);

        var apiConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        _model.AvailableCurrencies = await apiConnectClient.GetAsync();

        return new Pages.Configuration.PropertyLeaseOfferConfigurationPage(configurationSuccessAction, _model, new Validators.PropertyLeaseOfferConfigurationValidator());
    }
}
