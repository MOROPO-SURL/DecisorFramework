using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class LegalClientVehicleLeasingControlActionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel, Models.Page.Configuration.LegalClientVehicleLeasingControlActionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel, Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel, Models.Page.Configuration.LegalClientVehicleLeasingControlActionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel model)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SupervisionGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var _model = new Models.Page.Configuration.LegalClientVehicleLeasingControlActionConfigurationPageModel(model, await apiConnectClient.GetAsync());

        return new Pages.Configuration.LegalClientVehicleLeasingControlActionConfigurationPage(configurationSuccessAction, _model, new Validators.LegalClientVehicleLeasingControlActionConfigurationValidator());
    }
}