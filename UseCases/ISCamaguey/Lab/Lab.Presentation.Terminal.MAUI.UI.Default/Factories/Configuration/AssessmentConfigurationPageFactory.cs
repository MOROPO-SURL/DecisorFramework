using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

internal sealed class AssessmentConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.AssessmentDisplayModel, Models.Page.Configuration.AssessmentConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AssessmentDisplayModel, Interop.API.Common.Models.Display.AssessmentDisplayModel, Models.Page.Configuration.AssessmentConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.AssessmentDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.AssessmentDisplayModel model)
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        Interop.API.Connect.Clients.AnalysesAPIConnectClient analysesAPIConnectClient = new(httpClientHelperProvider);

        Models.Page.Configuration.AssessmentConfigurationPageModel _model = new(model);

        if (model != null) 
        {
            _model.Analyses = [.. await analysesAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.AnalysisFilterModel { SampleId = model.Sample.Id })];
        };

        return new Pages.Configuration.AssessmentConfigurationPage(configurationSuccessAction, _model, new Validators.AssessmentConfigurationValidator());
    }
}