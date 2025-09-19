using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PropertyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyDisplayModel, Models.Page.Configuration.PropertyConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PropertyDisplayModel, Interop.API.Common.Models.Display.PropertyDisplayModel, Models.Page.Configuration.PropertyConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PropertyDisplayModel model)
        {
            var _model = new Models.Page.Configuration.PropertyConfigurationPageModel(model);

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var kindsAPIConnectClient = new Interop.API.Connect.Clients.PropertyKindsAPIConnectClient(httpClientHelperProvider);
            var structuresAPIConnectClient = new Interop.API.Connect.Clients.ParentalStructuresAPIConnectClient(httpClientHelperProvider);

            _model.AvailableKinds = await kindsAPIConnectClient.GetAsync();
            _model.AvailableStructures = await structuresAPIConnectClient.GetEnabledAsync();

            return new Pages.Configuration.PropertyConfigurationPage(configurationSuccessAction, _model);
        }
    }
}
