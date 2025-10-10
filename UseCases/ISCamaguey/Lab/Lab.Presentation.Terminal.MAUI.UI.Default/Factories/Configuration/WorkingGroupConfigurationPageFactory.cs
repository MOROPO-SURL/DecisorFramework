namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class WorkingGroupConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkingGroupDisplayModel, Models.Page.Configuration.WorkingGroupConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WorkingGroupDisplayModel, Interop.API.Common.Models.Display.WorkingGroupDisplayModel, Models.Page.Configuration.WorkingGroupConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.WorkingGroupDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.WorkingGroupDisplayModel model)
        {
            return new Pages.Configuration.WorkingGroupConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.WorkingGroupConfigurationPageModel(model), new Validators.WorkingGroupConfigurationValidator());
        }
    }
}
