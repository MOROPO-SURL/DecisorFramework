using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class CostCenterConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.CostCenterDisplayModel, Models.Page.Configuration.CostCenterConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.CostCenterDisplayModel, Interop.API.Common.Models.Display.CostCenterDisplayModel, Models.Page.Configuration.CostCenterConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.CostCenterDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.CostCenterDisplayModel model)
        {
            var _model = new Models.Page.Configuration.CostCenterConfigurationPageModel(model);

            var apiConnectClient = new Domain.Interop.API.Connect.Clients.ParentalStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableStructures = await apiConnectClient.GetEnabledAsync();

            return new Pages.Configuration.CostCenterConfigurationPage(configurationSuccessAction, _model, new Validators.CostCenterConfigurationValidator());
        }
    }
}