using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class DecisionMakingGroupConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel model)
        {
            var _model = new Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel(model);

            var structuresAPIConnectClient = new Domain.Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableStructures = await structuresAPIConnectClient.GetEnabledAsync();

            return new Pages.Configuration.DecisionMakingGroupConfigurationPage(configurationSuccessAction, _model);
        }
    }
}