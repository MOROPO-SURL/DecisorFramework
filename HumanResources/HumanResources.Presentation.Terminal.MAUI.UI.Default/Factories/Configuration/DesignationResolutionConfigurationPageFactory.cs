namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class DesignationResolutionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel, Models.Page.Configuration.DesignationResolutionConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel, Interop.API.Common.Models.Display.DesignationResolutionDisplayModel, Models.Page.Configuration.DesignationResolutionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.DesignationResolutionDisplayModel model)
    {
        return new Pages.Configuration.DesignationResolutionConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.DesignationResolutionConfigurationPageModel(model), new Validators.DesignationResolutionConfigurationValidator());
    }
}