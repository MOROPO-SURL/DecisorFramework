namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class OrganizationContactConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Models.Page.Configuration.OrganizationContactConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Models.Page.Configuration.OrganizationContactConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel> configurationSuccessAction, Models.Page.Configuration.OrganizationContactConfigurationPageModel model)
        {
            return new Pages.Configuration.OrganizationContactConfigurationPage(configurationSuccessAction, model);
        }
    }
}
