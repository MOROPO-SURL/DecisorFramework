using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ExternalResearcherConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ExternalResearcherDisplayModel, Models.Page.Configuration.ExternalResearcherConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ExternalResearcherDisplayModel, Interop.API.Common.Models.Display.ExternalResearcherDisplayModel, Models.Page.Configuration.ExternalResearcherConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ExternalResearcherDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ExternalResearcherDisplayModel model)
        {
            var _model = new Models.Page.Configuration.ExternalResearcherConfigurationPageModel(model);

            var researcherCategoryAPIConnectClient = new Interop.API.Connect.Clients.ResearcherCategoriesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
            var teachingCategoryAPIConnectClient = new Interop.API.Connect.Clients.TeachingCategoriesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableResearcherCategories = await researcherCategoryAPIConnectClient.GetEnabledAsync();
            _model.AvailableTeachingCategories = await teachingCategoryAPIConnectClient.GetEnabledAsync();

            return new Pages.Configuration.ExternalResearcherConfigurationPage(configurationSuccessAction, _model, new Validators.ExternalResearcherConfigurationValidator());
        }
    }
}