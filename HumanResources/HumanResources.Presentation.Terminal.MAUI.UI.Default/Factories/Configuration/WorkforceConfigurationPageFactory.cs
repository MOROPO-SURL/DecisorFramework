using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class WorkforceConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkforceDisplayModel, Models.Page.Configuration.WorkforceConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WorkforceDisplayModel, Interop.API.Common.Models.Display.WorkforceDisplayModel, Models.Page.Configuration.WorkforceConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.WorkforceDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.WorkforceDisplayModel model)
    {
        var _model = new Models.Page.Configuration.WorkforceConfigurationPageModel(model);

        var apiConnectClient = new Domain.Interop.API.Connect.Clients.OrganizationalStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());
        
        _model.AvailableOrganizationalStructures = await apiConnectClient.GetAsync();

        return new Pages.Configuration.WorkforceConfigurationPage(configurationSuccessAction, _model, new Validators.WorkforceConfigurationValidator());
    }
}
