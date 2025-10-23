namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class CallForPropousalConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.CallForPropousalDisplayModel, Models.Page.Configuration.CallForPropousalConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.CallForPropousalDisplayModel, Interop.API.Common.Models.Display.CallForPropousalDisplayModel, Models.Page.Configuration.CallForPropousalConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.CallForPropousalDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.CallForPropousalDisplayModel model)
        {
            return new Pages.Configuration.CallForPropousalConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.CallForPropousalConfigurationPageModel(model), new Validators.CallForPropousalConfigurationValidator());
        }
    }
}
