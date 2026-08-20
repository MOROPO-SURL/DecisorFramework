namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class OrganizationalStructureConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel, Models.Page.Configuration.OrganizationalStructureConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel, Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel, Models.Page.Configuration.OrganizationalStructureConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel model)
    {
        return new Pages.Configuration.OrganizationalStructureConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.OrganizationalStructureConfigurationPageModel(model), new Validators.OrganizationalStructureConfigurationValidator());
    }
}
