using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class LegalClientPropertyLeasingControlActionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel, Models.Page.Configuration.LegalClientPropertyLeasingControlActionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel, Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel, Models.Page.Configuration.LegalClientPropertyLeasingControlActionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel model)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SupervisionGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var _model = new Models.Page.Configuration.LegalClientPropertyLeasingControlActionConfigurationPageModel(model, await apiConnectClient.GetAsync());

        return new Pages.Configuration.LegalClientPropertyLeasingControlActionConfigurationPage(configurationSuccessAction, _model, new Validators.LegalClientPropertyLeasingControlActionConfigurationValidator());
    }
}