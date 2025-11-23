using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class LegalClientServicingContractConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, Models.Page.Configuration.LegalClientServicingContractConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, Models.Page.Configuration.LegalClientServicingContractConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel model)
        {
            var _model = new Models.Page.Configuration.LegalClientServicingContractConfigurationPageModel(model);

            var apiConnectClient = new Framework.Decisor.Commercial.Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailablePaymentTerms = await apiConnectClient.GetAsync();

            return new Pages.Configuration.LegalClientServicingContractConfigurationPage(configurationSuccessAction, _model, new Validators.LegalClientServicingContractConfigurationValidator());
        }
    }
}
