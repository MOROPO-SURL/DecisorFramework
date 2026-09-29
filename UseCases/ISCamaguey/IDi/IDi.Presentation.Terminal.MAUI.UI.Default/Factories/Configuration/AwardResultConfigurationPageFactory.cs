using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class AwardResultConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.AwardResultDisplayModel, Models.Page.Configuration.AwardResultConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AwardResultDisplayModel, Interop.API.Common.Models.Display.AwardResultDisplayModel, Models.Page.Configuration.AwardResultConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.AwardResultDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.AwardResultDisplayModel model)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AwardKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return new Pages.Configuration.AwardResultConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.AwardResultConfigurationPageModel(model, await apiConnectClient.GetAsync()), new Validators.AwardResultConfigurationValidator());
    }
}