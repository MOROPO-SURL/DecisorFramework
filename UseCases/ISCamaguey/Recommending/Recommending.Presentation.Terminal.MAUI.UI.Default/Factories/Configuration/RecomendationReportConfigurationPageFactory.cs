namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class RecomendationReportConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.RecomendationReportDisplayModel, Models.Page.Configuration.RecomendationReportConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.RecomendationReportDisplayModel, Interop.API.Common.Models.Display.RecomendationReportDisplayModel, Models.Page.Configuration.RecomendationReportConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.RecomendationReportDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.RecomendationReportDisplayModel model)
    {
        return new Pages.Configuration.RecomendationReportConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.RecomendationReportConfigurationPageModel(model), new Validators.RecomendationReportConfigurationValidator());
    }
}