namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class OrganizationalUnitConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel, Models.Page.Configuration.OrganizationalUnitConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel, Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel, Models.Page.Configuration.OrganizationalUnitConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel model)
    {
        return new Pages.Configuration.OrganizationalUnitConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.OrganizationalUnitConfigurationPageModel(model), new Validators.OrganizationalUnitConfigurationValidator());
    }
}