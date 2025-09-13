namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class OrganizationConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationDisplayModel, Models.Page.Configuration.OrganizationConfigurationPageModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.OrganizationDisplayModel, Interop.API.Common.Models.Display.OrganizationDisplayModel, Models.Page.Configuration.OrganizationConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.OrganizationDisplayModel> configurationSuccessAction, Models.Page.Configuration.OrganizationConfigurationPageModel model)
        {
            return new UI.Pages.Configuration.OrganizationConfigurationPage(configurationSuccessAction, model);
        }
    }
}
