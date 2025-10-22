using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class FamilyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.FamilyDisplayModel, Models.Page.Configuration.FamilyConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.FamilyDisplayModel, Interop.API.Common.Models.Display.FamilyDisplayModel, Models.Page.Configuration.FamilyConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.FamilyDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.FamilyDisplayModel model)
        {
            var _model = new Models.Page.Configuration.FamilyConfigurationPageModel(model);

            var categoriesAPIConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            var families = new System.Collections.Generic.List<Interop.API.Common.Models.Display.FamilyDisplayModel>(await categoriesAPIConnectClient.GetAsync());

            if (model != null)
            {
                families.RemoveAll(_model => _model.Id == model.Id);
            }

            _model.AvailableParents = families.ToArray();

            return new Pages.Configuration.FamilyConfigurationPage(configurationSuccessAction, _model, new Validators.FamilyConfigurationValidator());
        }
    }
}
