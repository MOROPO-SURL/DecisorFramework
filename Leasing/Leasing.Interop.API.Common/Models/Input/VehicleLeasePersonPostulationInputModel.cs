namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class VehicleLeasePersonPostulationInputModel : Contract.AbstractLeasePersonPostulationInputModel<Persistence.Entities.VehicleLeasePersonPostulation>
    {
        public System.Guid OfferId { get; set; }

        public override Persistence.Entities.VehicleLeasePersonPostulation Export()
        {
            var entity = new Persistence.Entities.VehicleLeasePersonPostulation { Id = Id, OfferId = OfferId };

            Mergue(entity);

            return entity;
        }
    }
}
