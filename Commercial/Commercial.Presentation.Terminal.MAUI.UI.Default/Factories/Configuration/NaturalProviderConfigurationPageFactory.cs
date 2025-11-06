using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class NaturalProviderConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Models.Page.Configuration.NaturalProviderConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Models.Page.Configuration.NaturalProviderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalProviderDisplayModel model)
        {
            var _model = new Models.Page.Configuration.NaturalProviderConfigurationPageModel(model);

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var paymentTermsAPIConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);
            var businessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(httpClientHelperProvider);

            _model.AvailablePaymentTerms = await paymentTermsAPIConnectClient.GetEnabledAsync();
            _model.AvailableBusinessKinds = await businessKindsAPIConnectClient.GetEnabledAsync();

            return new Pages.Configuration.NaturalProviderConfigurationPage(configurationSuccessAction, _model, new Validators.NaturalProviderConfigurationValidator());
        }
    }
}
