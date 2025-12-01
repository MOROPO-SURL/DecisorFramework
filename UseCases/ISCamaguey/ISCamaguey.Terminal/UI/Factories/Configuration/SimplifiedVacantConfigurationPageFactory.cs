using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Factories.Configuration;

public class SimplifiedVacantConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.VacantConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.VacantConfigurationPageModel>> BuildAsync(System.Action<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel> configurationSuccessAction, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var _model = new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.VacantConfigurationPageModel(model);

        var workPositionsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
        var salaryStandardsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.SalaryStandardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        _model.AvailableWorkPositions = await workPositionsAPIConnectClient.GetAsync();
        _model.AvailableSalaryStandards = await salaryStandardsAPIConnectClient.GetAsync();

        return new Pages.Configuration.SimplifiedVacantConfigurationPage(configurationSuccessAction, _model, new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators.VacantConfigurationValidator());
    }
}