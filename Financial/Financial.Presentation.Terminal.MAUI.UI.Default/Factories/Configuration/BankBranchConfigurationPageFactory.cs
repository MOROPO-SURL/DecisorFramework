using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class BankBranchConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.BankBranchDisplayModel, Models.Page.Configuration.BankBranchConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.BankBranchDisplayModel, Interop.API.Common.Models.Display.BankBranchDisplayModel, Models.Page.Configuration.BankBranchConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.BankBranchDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.BankBranchDisplayModel model)
        {
            var _model = new Models.Page.Configuration.BankBranchConfigurationPageModel(model);

            var apiConnectClient = new Interop.API.Connect.Clients.BankAgenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableAgencies = await apiConnectClient.GetAsync();
            
            return new Pages.Configuration.BankBranchConfigurationPage(configurationSuccessAction, _model, new Validators.BankBranchConfigurationValidator());
        }
    }
}