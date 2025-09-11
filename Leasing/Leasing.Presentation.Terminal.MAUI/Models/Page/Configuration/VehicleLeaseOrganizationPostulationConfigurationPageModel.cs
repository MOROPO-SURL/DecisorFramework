namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleLeaseOrganizationPostulationConfigurationPageModel : Contract.AbstractLeaseOrganizationPostulationConfigurationPageModel<Interop.API.Common.Models.Display.VehicleLeaseOrganizationPostulationDisplayModel, Persistence.Entities.VehicleLeaseOrganizationPostulation>
    {
        public VehicleLeaseOrganizationPostulationConfigurationPageModel(System.Guid offerId, Interop.API.Common.Models.Display.VehicleLeaseOrganizationPostulationDisplayModel model) : base(offerId, model)
        {
        }
    }
}
