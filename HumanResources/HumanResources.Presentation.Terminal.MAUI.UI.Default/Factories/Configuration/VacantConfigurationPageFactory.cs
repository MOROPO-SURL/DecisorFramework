using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class VacantConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Models.View.WorkforceConfigurationVacantViewModel, Models.Page.Configuration.VacantConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Models.View.WorkforceConfigurationVacantViewModel, Models.View.WorkforceConfigurationVacantViewModel, Models.Page.Configuration.VacantConfigurationPageModel>> BuildAsync(System.Action<Models.View.WorkforceConfigurationVacantViewModel> configurationSuccessAction, Models.View.WorkforceConfigurationVacantViewModel model)
    {
        var _model = new Models.Page.Configuration.VacantConfigurationPageModel(model);

        var workPositionsAPIConnectClient = new Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
        var salaryStandardsAPIConnectClient = new Interop.API.Connect.Clients.SalaryStandardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        _model.AvailableWorkPositions = await workPositionsAPIConnectClient.GetAsync();
        _model.AvailableSalaryStandards = await salaryStandardsAPIConnectClient.GetAsync();

        return new Pages.Configuration.VacantConfigurationPage(configurationSuccessAction, _model, new Validators.VacantConfigurationValidator());
    }
}
