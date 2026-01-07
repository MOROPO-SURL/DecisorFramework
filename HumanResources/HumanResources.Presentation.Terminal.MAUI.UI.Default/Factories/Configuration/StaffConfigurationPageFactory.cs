using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class StaffConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.StaffDisplayModel, Models.Page.Configuration.StaffConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.StaffDisplayModel, Interop.API.Common.Models.Display.StaffDisplayModel, Models.Page.Configuration.StaffConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.StaffDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.StaffDisplayModel model)
    {
        var _model = new Models.Page.Configuration.StaffConfigurationPageModel(model);

        var structuresAPIConnectClient = new Domain.Interop.API.Connect.Clients.ParentalStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());
        var workforcesAPIConnectClient = new Interop.API.Connect.Clients.WorkforcesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        _model.AvailableStructures = await structuresAPIConnectClient.GetEnabledAsync();
        _model.AvailableWorkforces = [.. await workforcesAPIConnectClient.GetAsync()];

        return new Pages.Configuration.StaffConfigurationPage(configurationSuccessAction, _model, new Validators.StaffConfigurationValidator());
    }
}