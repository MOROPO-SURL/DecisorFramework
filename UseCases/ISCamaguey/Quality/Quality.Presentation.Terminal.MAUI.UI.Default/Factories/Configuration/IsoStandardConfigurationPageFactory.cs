
namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class IsoStandardConfigurationPageFactory: Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.IsoStandardDisplayModel, Models.Page.Configuration.IsoStandardConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.IsoStandardDisplayModel, Interop.API.Common.Models.Display.IsoStandardDisplayModel, Models.Page.Configuration.IsoStandardConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.IsoStandardDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.IsoStandardDisplayModel model)
        {
            return new Pages.Configuration.IsoStandardConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.IsoStandardConfigurationPageModel(model), new Validators.IsoStandardConfigurationValidator());
        }
    }
}
