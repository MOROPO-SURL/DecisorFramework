namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class SupervisionGroupConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SupervisionGroupDisplayModel, Models.Page.Configuration.SupervisionGroupConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SupervisionGroupDisplayModel, Interop.API.Common.Models.Display.SupervisionGroupDisplayModel, Models.Page.Configuration.SupervisionGroupConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.SupervisionGroupDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.SupervisionGroupDisplayModel model)
        {
            return new Pages.Configuration.SupervisionGroupConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.SupervisionGroupConfigurationPageModel(model));
        }
    }
}
