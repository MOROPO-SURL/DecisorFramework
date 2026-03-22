using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Factories.Configuration;

public class SimplifiedStaffConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.StaffConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel, Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.StaffConfigurationPageModel>> BuildAsync(System.Action<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel> configurationSuccessAction, Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel model)
    {
        var _model = new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.StaffConfigurationPageModel(model);

        var administrativeEntitiesAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());
        var workforcesAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.WorkforcesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        _model.AvailableAdministrativeEntities = await administrativeEntitiesAPIConnectClient.GetEnabledAsync();

        if (model != null) _model.AvailableWorkforces = [.. await workforcesAPIConnectClient.FilterAsync(new Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter.WorkforceFilterModel { OrganizationalStructure = model.AdministrativeEntity.OrganizationalStructure })];

        return new Pages.Configuration.SimplifiedStaffConfigurationPage(configurationSuccessAction, _model, new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators.StaffConfigurationValidator());
    }
}