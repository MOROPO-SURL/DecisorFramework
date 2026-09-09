using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class AnalysisConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.AnalysisDisplayModel, Models.Page.Configuration.AnalysisConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AnalysisDisplayModel, Interop.API.Common.Models.Display.AnalysisDisplayModel, Models.Page.Configuration.AnalysisConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.AnalysisDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.AnalysisDisplayModel model)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        Domain.Interop.API.Connect.Clients.TechniquesAPIConnectClient techniquesAPIConnectClient = new(httpClientHelperProvider);

        Models.Page.Configuration.AnalysisConfigurationPageModel _model = new(model, await techniquesAPIConnectClient.GetAsync());

        return new Pages.Configuration.AnalysisConfigurationPage(configurationSuccessAction, _model, new Validators.AnalysisConfigurationValidator());
    }
}