namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class SupervisionGroupConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SupervisionGroupDisplayModel, Models.Page.Configuration.SupervisionGroupConfigurationPageModel, Pages.Configuration.SupervisionGroupConfigurationPage>
    {
        public Pages.Configuration.SupervisionGroupConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.SupervisionGroupDisplayModel> configurationSuccessAction, Models.Page.Configuration.SupervisionGroupConfigurationPageModel model)
        {
            return new Pages.Configuration.SupervisionGroupConfigurationPage(configurationSuccessAction, model);
        }
    }
}
