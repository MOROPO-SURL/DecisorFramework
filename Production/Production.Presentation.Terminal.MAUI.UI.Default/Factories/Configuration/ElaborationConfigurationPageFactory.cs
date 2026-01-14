using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ElaborationConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ElaborationDisplayModel, Models.Page.Configuration.ElaborationConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ElaborationDisplayModel, Interop.API.Common.Models.Display.ElaborationDisplayModel, Models.Page.Configuration.ElaborationConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ElaborationDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ElaborationDisplayModel model)
    {
        var _model = new Models.Page.Configuration.ElaborationConfigurationPageModel(model);

        if (model != null && model.Classification != null)
        {
            var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            _model.AvailableClassifications = [.. await classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = model.Product.Id })];
        }

        return new Pages.Configuration.ElaborationConfigurationPage(configurationSuccessAction, _model, new Validators.ElaborationConfigurationValidator());
    }
}
