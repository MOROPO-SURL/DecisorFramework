namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class PropertyLeasePropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel model)
        {
            return new Pages.Configuration.PropertyLeasePropousalConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel(model), new Validators.PropertyLeasePropousalConfigurationValidator());
        }
    }
}
