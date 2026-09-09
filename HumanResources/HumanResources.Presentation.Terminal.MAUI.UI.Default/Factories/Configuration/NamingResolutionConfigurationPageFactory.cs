namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class NamingResolutionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Models.Page.Configuration.NamingResolutionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Models.Page.Configuration.NamingResolutionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.NamingResolutionDisplayModel model)
    {
        return new Pages.Configuration.NamingResolutionConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.NamingResolutionConfigurationPageModel(model), new Validators.NamingResolutionConfigurationValidator());
    }
}