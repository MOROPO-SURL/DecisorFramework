using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ProjectConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProjectDisplayModel, Models.Page.Configuration.ProjectConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProjectDisplayModel, Interop.API.Common.Models.Display.ProjectDisplayModel, Models.Page.Configuration.ProjectConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProjectDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProjectDisplayModel model)
    {
        var _model = new Models.Page.Configuration.ProjectConfigurationPageModel(model);

        var categoriesAPIConnectClient = new Interop.API.Connect.Clients.ProjectCategoriesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        _model.AvailableCategories = await categoriesAPIConnectClient.GetEnabledAsync();

        return new Pages.Configuration.ProjectConfigurationPage(configurationSuccessAction, _model, new Validators.ProjectConfigurationValidator());
    }
}
