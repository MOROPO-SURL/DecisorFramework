using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class OrganizationContactConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Models.Page.Configuration.OrganizationContactConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Models.Page.Configuration.OrganizationContactConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.OrganizationContactDisplayModel model)
        {
            var _model = new Models.Page.Configuration.OrganizationContactConfigurationPageModel(model);

            var apiConnectClient = new Interop.API.Connect.Clients.LegalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableBusinessKinds = await apiConnectClient.GetEnabledAsync();

            return new Pages.Configuration.OrganizationContactConfigurationPage(configurationSuccessAction, _model, new Validators.OrganizationContactConfigurationValidator());
        }
    }
}
