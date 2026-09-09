using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ProductionSampleConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionSampleDisplayModel, Models.Page.Configuration.ProductionSampleConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProductionSampleDisplayModel, Interop.API.Common.Models.Display.ProductionSampleDisplayModel, Models.Page.Configuration.ProductionSampleConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProductionSampleDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProductionSampleDisplayModel model)
    {
        var _model = new Models.Page.Configuration.ProductionSampleConfigurationPageModel(model);

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var unitMeasurementsAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientHelperProvider);
        var sampleKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.SampleKindsAPIConnectClient(httpClientHelperProvider);

        _model.AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync();
        _model.AvailableSampleKinds = await sampleKindsAPIConnectClient.GetAsync();

        return new Pages.Configuration.ProductionSampleConfigurationPage(configurationSuccessAction, _model, new Validators.ProductionSampleConfigurationValidator());
    }
}