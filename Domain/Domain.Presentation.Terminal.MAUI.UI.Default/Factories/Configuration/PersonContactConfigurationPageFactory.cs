using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PersonContactConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PersonContactDisplayModel, Models.Page.Configuration.PersonContactConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PersonContactDisplayModel, Interop.API.Common.Models.Display.PersonContactDisplayModel, Models.Page.Configuration.PersonContactConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PersonContactDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PersonContactDisplayModel model)
        {
            var _model = new Models.Page.Configuration.PersonContactConfigurationPageModel(model);

            var apiConnectClient = new Core.Interop.API.Connect.Clients.UsersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableUsers = await apiConnectClient.GetAsync();

            return new Pages.Configuration.PersonContactConfigurationPage(configurationSuccessAction, _model, new Validators.PersonContactConfigurationValidator());
        }
    }
}
