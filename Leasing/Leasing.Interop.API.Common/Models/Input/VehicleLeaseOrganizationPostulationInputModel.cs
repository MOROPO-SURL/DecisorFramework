namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class VehicleLeaseOrganizationPostulationInputModel : Contract.AbstractLeaseOrganizationPostulationInputModel<Persistence.Entities.VehicleLeaseOrganizationPostulation>
    {
        public System.Guid OfferId { get; set; }

        public override Persistence.Entities.VehicleLeaseOrganizationPostulation Export()
        {
            var entity = new Persistence.Entities.VehicleLeaseOrganizationPostulation { Id = Id, OfferId = OfferId };

            Mergue(entity);

            return entity;
        }
    }
}
