using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class WorkPlanConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkPlanDisplayModel, Models.Page.Configuration.WorkPlanConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WorkPlanDisplayModel, Interop.API.Common.Models.Display.WorkPlanDisplayModel, Models.Page.Configuration.WorkPlanConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.WorkPlanDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.WorkPlanDisplayModel model)
    {
        Interop.API.Connect.Clients.WorkingGroupsAPIConnectClient workingGroupsAPIConnectClient = new(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        Models.Page.Configuration.WorkPlanConfigurationPageModel _model = new(model, await workingGroupsAPIConnectClient.GetAsync());

        return new Pages.Configuration.WorkPlanConfigurationPage(configurationSuccessAction, _model, new Validators.WorkPlanConfigurationValidator());
    }
}