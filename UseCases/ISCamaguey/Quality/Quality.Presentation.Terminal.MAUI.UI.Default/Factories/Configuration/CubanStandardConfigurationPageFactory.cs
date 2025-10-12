
namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class CubanStandardConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.CubanStandardDisplayModel, Models.Page.Configuration.CubanStandardConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.CubanStandardDisplayModel, Interop.API.Common.Models.Display.CubanStandardDisplayModel, Models.Page.Configuration.CubanStandardConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.CubanStandardDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.CubanStandardDisplayModel model)
        {
            return new Pages.Configuration.CubanStandardConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.CubanStandardConfigurationPageModel(model), new Validators.CubanStandardConfigurationValidator());
        }
    }
}
