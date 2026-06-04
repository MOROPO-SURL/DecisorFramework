using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class InternalResearcherConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.InternalResearcherDisplayModel, Models.Page.Configuration.InternalResearcherConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.InternalResearcherDisplayModel, Interop.API.Common.Models.Display.InternalResearcherDisplayModel, Models.Page.Configuration.InternalResearcherConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.InternalResearcherDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.InternalResearcherDisplayModel model)
        {
            var _model = new Models.Page.Configuration.InternalResearcherConfigurationPageModel(model);

            var researcherCategoryAPIConnectClient = new Interop.API.Connect.Clients.ResearcherCategoriesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
            var teachingCategoryAPIConnectClient = new Interop.API.Connect.Clients.TeachingCategoriesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableResearcherCategories = await researcherCategoryAPIConnectClient.GetEnabledAsync();
            _model.AvailableTeachingCategories = await teachingCategoryAPIConnectClient.GetEnabledAsync();

            return new Pages.Configuration.InternalResearcherConfigurationPage(configurationSuccessAction, _model, new Validators.InternalResearcherConfigurationValidator());
        }
    }
}
