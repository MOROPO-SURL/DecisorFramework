namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VehicleLeasePropousalConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel model)
        {
            return new Pages.Configuration.VehicleLeasePropousalConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel(model));
        }
    }
}
