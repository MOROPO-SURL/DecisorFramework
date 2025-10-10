using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class NaturalClientConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientDisplayModel, Models.Page.Configuration.NaturalClientConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientDisplayModel, Interop.API.Common.Models.Display.NaturalClientDisplayModel, Models.Page.Configuration.NaturalClientConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalClientDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalClientDisplayModel model)
        {
            var _model = new Models.Page.Configuration.NaturalClientConfigurationPageModel(model);

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var paymentTermsAPIConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);
            var businessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(httpClientHelperProvider);

            _model.AvailablePaymentTerms = await paymentTermsAPIConnectClient.GetEnabledAsync();
            _model.AvailableBusinessKinds = await businessKindsAPIConnectClient.GetEnabledAsync();

            return new Pages.Configuration.NaturalClientConfigurationPage(configurationSuccessAction, _model);
        }
    }
}