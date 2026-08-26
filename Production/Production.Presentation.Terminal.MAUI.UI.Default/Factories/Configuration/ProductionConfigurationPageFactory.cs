using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ProductionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionDisplayModel, Models.Page.Configuration.ProductionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProductionDisplayModel, Interop.API.Common.Models.Display.ProductionDisplayModel, Models.Page.Configuration.ProductionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProductionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProductionDisplayModel model)
    {
        Models.Page.Configuration.ProductionConfigurationPageModel pageModel = new(model);

        if (model != null)
        {
            var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

            pageModel.AvailableUnitMeasurements = [.. await unitMeasurementsAPIConnectClient.GetReleatedsAsync(model.UnitMeasurement.Id)];
        }

        return new Pages.Configuration.ProductionConfigurationPage(configurationSuccessAction, pageModel, new Validators.ProductionConfigurationValidator());
    }
}