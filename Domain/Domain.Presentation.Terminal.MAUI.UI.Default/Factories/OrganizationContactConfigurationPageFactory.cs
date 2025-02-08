namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class OrganizationContactConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Models.Page.Configuration.OrganizationContactConfigurationPageModel, Pages.Configuration.OrganizationContactConfigurationPage>
    {
        public Pages.Configuration.OrganizationContactConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel> configurationSuccessAction, Models.Page.Configuration.OrganizationContactConfigurationPageModel model)
        {
            return new Pages.Configuration.OrganizationContactConfigurationPage(configurationSuccessAction, model);
        }
    }
}
