namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ResearchAreaConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ResearchAreaDisplayModel, Models.Page.Configuration.ResearchAreaConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ResearchAreaDisplayModel, Interop.API.Common.Models.Display.ResearchAreaDisplayModel, Models.Page.Configuration.ResearchAreaConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ResearchAreaDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ResearchAreaDisplayModel model)
        {
            return new Pages.Configuration.ResearchAreaConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ResearchAreaConfigurationPageModel(model), new Validators.ResearchAreaConfigurationValidator());
        }
    }
}