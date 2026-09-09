using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ProgramConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProgramDisplayModel, Models.Page.Configuration.ProgramConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProgramDisplayModel, Interop.API.Common.Models.Display.ProgramDisplayModel, Models.Page.Configuration.ProgramConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProgramDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProgramDisplayModel model)
    {
        var _model = new Models.Page.Configuration.ProgramConfigurationPageModel(model);

        var kindAPIConnectClient = new Interop.API.Connect.Clients.ProgramKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        _model.AvailableKinds = await kindAPIConnectClient.GetEnabledAsync();

        return new Pages.Configuration.ProgramConfigurationPage(configurationSuccessAction, _model, new Validators.ProgramConfigurationValidator());
    }
}