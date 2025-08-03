namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class VehicleLeasePropousal : Contract.AbstractLeasePropousal
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleId))]
        public Domain.Persistence.Entities.Vehicle Vehicle { get; set; }
        public System.Guid VehicleId { get; set; }
    }
}
