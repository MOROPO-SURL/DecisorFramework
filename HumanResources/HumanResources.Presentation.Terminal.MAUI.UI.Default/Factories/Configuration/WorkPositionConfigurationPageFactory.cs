using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class WorkPositionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkPositionDisplayModel, Models.Page.Configuration.WorkPositionConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WorkPositionDisplayModel, Interop.API.Common.Models.Display.WorkPositionDisplayModel, Models.Page.Configuration.WorkPositionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.WorkPositionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.WorkPositionDisplayModel model)
        {
            var _model = new Models.Page.Configuration.WorkPositionConfigurationPageModel(model);

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var kindsAPIConnectClient = new Interop.API.Connect.Clients.WorkPositionKindsAPIConnectClient(httpClientHelperProvider);
            
            _model.AvailableKinds = await kindsAPIConnectClient.GetAsync();
            
            return new Pages.Configuration.WorkPositionConfigurationPage(configurationSuccessAction, _model);
        }
    }
}
