namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PropertyLeasePropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel> configurationSuccessAction, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel model)
        {
            return new Pages.Configuration.PropertyLeasePropousalConfigurationPage(configurationSuccessAction, model);
        }
    }
}
