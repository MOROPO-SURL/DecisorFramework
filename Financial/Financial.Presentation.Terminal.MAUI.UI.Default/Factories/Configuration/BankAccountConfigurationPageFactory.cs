using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class BankAccountConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.BankAccountDisplayModel, Models.Page.Configuration.BankAccountConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.BankAccountDisplayModel, Interop.API.Common.Models.Display.BankAccountDisplayModel, Models.Page.Configuration.BankAccountConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.BankAccountDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.BankAccountDisplayModel model)
        {
            var _model = new Models.Page.Configuration.BankAccountConfigurationPageModel(model);

            var bankBranchsAPIConnectClient = new Interop.API.Connect.Clients.BankBranchesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());
            var currenciesAPIConnectClient = new Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

            _model.AvailableBankBranches = await bankBranchsAPIConnectClient.GetAsync();
            _model.AvailableCurrencies = await currenciesAPIConnectClient.GetAsync();

            return new Pages.Configuration.BankAccountConfigurationPage(configurationSuccessAction, _model, new Validators.BankAccountConfigurationValidator());
        }
    }
}
