namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class ProgramConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ProgramDisplayModel, Models.Page.Configuration.ProgramConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProgramDisplayModel, Interop.API.Common.Models.Display.ProgramDisplayModel, Models.Page.Configuration.ProgramConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ProgramDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ProgramDisplayModel model)
        {
            return new Pages.Configuration.ProgramConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ProgramConfigurationPageModel(model), new Validators.ProgramConfigurationValidator());
        }
    }
}
