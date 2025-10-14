namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class VehicleLeaseOrganizationPostulationDisplayModel : Contract.AbstractLeaseOrganizationPostulationDisplayModel<Persistence.Entities.VehicleLeaseOrganizationPostulation>
    {
        public override void Import(Persistence.Entities.VehicleLeaseOrganizationPostulation entity)
        {
            base.Import(entity);

            OfferId = entity.OfferId;
        }
    }
}
