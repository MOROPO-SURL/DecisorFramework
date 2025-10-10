using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ProductionOrderConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Models.Page.Configuration.ProductionOrderConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Models.Page.Configuration.ProductionOrderConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProductionOrderDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProductionOrderDisplayModel model)
        {
            var _model = new Models.Page.Configuration.ProductionOrderConfigurationPageModel(model);

            var employeesAPIConnectClient = new Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            var employees = await employeesAPIConnectClient.GetAsync();

            _model.AvailableAuthors = employees;
            _model.AvailableResponsibles = employees;
            _model.AvailableDecisors = employees;

            return new Pages.Configuration.ProductionOrderConfigurationPage(configurationSuccessAction, _model);
        }
    }
}
