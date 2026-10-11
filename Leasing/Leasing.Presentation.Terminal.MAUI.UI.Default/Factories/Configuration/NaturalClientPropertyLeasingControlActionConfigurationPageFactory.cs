using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class NaturalClientPropertyLeasingControlActionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel, Models.Page.Configuration.NaturalClientPropertyLeasingControlActionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel, Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel, Models.Page.Configuration.NaturalClientPropertyLeasingControlActionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel model)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SupervisionGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var _model = new Models.Page.Configuration.NaturalClientPropertyLeasingControlActionConfigurationPageModel(model, await apiConnectClient.GetAsync());

        return new Pages.Configuration.NaturalClientPropertyLeasingControlActionConfigurationPage(configurationSuccessAction, _model, new Validators.NaturalClientPropertyLeasingControlActionConfigurationValidator());
    }
}