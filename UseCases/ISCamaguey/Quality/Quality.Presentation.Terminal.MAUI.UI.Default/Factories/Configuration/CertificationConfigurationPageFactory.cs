
using MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Models.Page.Configuration;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class CertificationConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.CertificationDisplayModel, Models.Page.Configuration.CertificationConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.CertificationDisplayModel, Interop.API.Common.Models.Display.CertificationDisplayModel, Models.Page.Configuration.CertificationConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.CertificationDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.CertificationDisplayModel model)
        {
            return new Pages.Configuration.CertificationConfigurationPage(configurationSuccessAction, new CertificationConfigurationPageModel(model), new Validators.CertificationConfigurationValidator());
        }
    }
}
