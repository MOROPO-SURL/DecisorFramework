namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleLeasePersonPostulationConfigurationPageModel : Contract.AbstractLeasePersonPostulationConfigurationPageModel<Interop.API.Common.Models.Display.VehicleLeasePersonPostulationDisplayModel, Persistence.Entities.VehicleLeasePersonPostulation>
    {
        public VehicleLeasePersonPostulationConfigurationPageModel(System.Guid offerId, Interop.API.Common.Models.Display.VehicleLeasePersonPostulationDisplayModel model) : base(offerId, model)
        {
        }
    }
}
