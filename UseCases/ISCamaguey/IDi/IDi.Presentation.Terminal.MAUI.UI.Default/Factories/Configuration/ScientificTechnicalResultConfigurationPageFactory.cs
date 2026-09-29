using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ScientificTechnicalResultConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel, Models.Page.Configuration.ScientificTechnicalResultConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel, Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel, Models.Page.Configuration.ScientificTechnicalResultConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel model)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ScientificTechnicalResultKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return new Pages.Configuration.ScientificTechnicalResultConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ScientificTechnicalResultConfigurationPageModel(model, await apiConnectClient.GetAsync()), new Validators.ScientificTechnicalResultConfigurationValidator());
    }
}