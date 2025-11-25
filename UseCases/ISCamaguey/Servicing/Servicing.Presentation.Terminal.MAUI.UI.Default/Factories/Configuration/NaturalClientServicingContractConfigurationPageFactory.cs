using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class NaturalClientServicingContractConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel, Models.Page.Configuration.NaturalClientServicingContractConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel, Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel, Models.Page.Configuration.NaturalClientServicingContractConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel model)
    {
        var _model = new Models.Page.Configuration.NaturalClientServicingContractConfigurationPageModel(model);

        var apiConnectClient = new Framework.Decisor.Commercial.Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        _model.AvailablePaymentTerms = await apiConnectClient.GetAsync();

        return new Pages.Configuration.NaturalClientServicingContractConfigurationPage(configurationSuccessAction, _model, new Validators.NaturalClientServicingContractConfigurationValidator());
    }
}