namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VehicleLeasePropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel, Pages.Configuration.VehicleLeasePropousalConfigurationPage>
    {
        public Pages.Configuration.VehicleLeasePropousalConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel> configurationSuccessAction, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel model)
        {
            return new Pages.Configuration.VehicleLeasePropousalConfigurationPage(configurationSuccessAction, model);
        }
    }
}
