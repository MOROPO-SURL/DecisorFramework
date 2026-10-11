using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class NaturalClientVehicleLeasingControlActionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel, Models.Page.Configuration.NaturalClientVehicleLeasingControlActionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel, Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel, Models.Page.Configuration.NaturalClientVehicleLeasingControlActionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel model)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SupervisionGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var _model = new Models.Page.Configuration.NaturalClientVehicleLeasingControlActionConfigurationPageModel(model, await apiConnectClient.GetAsync());

        return new Pages.Configuration.NaturalClientVehicleLeasingControlActionConfigurationPage(configurationSuccessAction, _model, new Validators.NaturalClientVehicleLeasingControlActionConfigurationValidator());
    }
}