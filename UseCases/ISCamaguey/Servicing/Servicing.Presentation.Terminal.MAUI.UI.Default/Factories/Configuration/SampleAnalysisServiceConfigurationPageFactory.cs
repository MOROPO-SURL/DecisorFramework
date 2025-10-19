namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class SampleAnalysisServiceConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel, Models.Page.Configuration.SampleAnalysisServiceConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel, Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel, Models.Page.Configuration.SampleAnalysisServiceConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel model)
        {
            return new Pages.Configuration.SampleAnalysisServiceConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.SampleAnalysisServiceConfigurationPageModel(model), new Validators.SampleAnalysisServiceConfigurationValidator());
        }
    }
}
