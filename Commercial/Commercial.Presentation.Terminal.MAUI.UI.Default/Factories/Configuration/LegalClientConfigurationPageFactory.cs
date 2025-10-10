using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class LegalClientConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientDisplayModel, Models.Page.Configuration.LegalClientConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientDisplayModel, Interop.API.Common.Models.Display.LegalClientDisplayModel, Models.Page.Configuration.LegalClientConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientDisplayModel model)
        {
            var _model = new Models.Page.Configuration.LegalClientConfigurationPageModel(model);

            var apiConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailablePaymentTerms = await apiConnectClient.GetEnabledAsync();

            return new Pages.Configuration.LegalClientConfigurationPage(configurationSuccessAction, _model, new Validators.LegalClientConfigurationValidator());
        }
    }
}
