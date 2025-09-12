namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VehicleLeasePropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel> configurationSuccessAction, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel model)
        {
            return new Pages.Configuration.VehicleLeasePropousalConfigurationPage(configurationSuccessAction, model);
        }
    }
}
