using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class MeetingConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.MeetingDisplayModel, Models.Page.Configuration.MeetingConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.MeetingDisplayModel, Interop.API.Common.Models.Display.MeetingDisplayModel, Models.Page.Configuration.MeetingConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.MeetingDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.MeetingDisplayModel model)
    {
        var _model = new Models.Page.Configuration.MeetingConfigurationPageModel(model);

        var groupsAPIConnectClient = new Interop.API.Connect.Clients.DecisionMakingGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        _model.AvailableGroups = await groupsAPIConnectClient.GetAsync();

        return new Pages.Configuration.MeetingConfigurationPage(configurationSuccessAction, _model, new Validators.MeetingConfigurationValidator());
    }
}