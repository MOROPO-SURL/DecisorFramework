using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class LegalProviderConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalProviderDisplayModel, Models.Page.Configuration.LegalProviderConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalProviderDisplayModel, Interop.API.Common.Models.Display.LegalProviderDisplayModel, Models.Page.Configuration.LegalProviderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalProviderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalProviderDisplayModel model)
        {
            var _model = new Models.Page.Configuration.LegalProviderConfigurationPageModel(model);

            var apiConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailablePaymentTerms = await apiConnectClient.GetEnabledAsync();

            return new Pages.Configuration.LegalProviderConfigurationPage(configurationSuccessAction, _model);
        }
    }
}