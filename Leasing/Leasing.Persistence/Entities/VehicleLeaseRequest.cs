namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class VehicleLeaseRequest : Contract.AbstractLeaseRequest
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleId))]
        public Domain.Persistence.Entities.Vehicle Vehicle { get; set; }
        public System.Guid VehicleId { get; set; }
    }
}
