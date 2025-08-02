namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VehicleConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleDisplayModel, Models.Page.Configuration.VehicleConfigurationPageModel, Pages.Configuration.VehicleConfigurationPage>
    {
        public Pages.Configuration.VehicleConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.VehicleDisplayModel> configurationSuccessAction, Models.Page.Configuration.VehicleConfigurationPageModel model)
        {
            return new Pages.Configuration.VehicleConfigurationPage(configurationSuccessAction, model);
        }
    }
}