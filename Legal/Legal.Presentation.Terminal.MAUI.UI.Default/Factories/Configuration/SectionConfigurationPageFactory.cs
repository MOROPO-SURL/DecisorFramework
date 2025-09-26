using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class SectionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SectionDisplayModel, Models.Page.Configuration.SectionConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SectionDisplayModel, Interop.API.Common.Models.Display.SectionDisplayModel, Models.Page.Configuration.SectionConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.SectionDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.SectionDisplayModel model)
        {
            var _model = new Models.Page.Configuration.SectionConfigurationPageModel(model);

            var categoriesAPIConnectClient = new Interop.API.Connect.Clients.SectionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableParents = await categoriesAPIConnectClient.GetAsync();

            return new Pages.Configuration.SectionConfigurationPage(configurationSuccessAction, _model);
        }
    }
}