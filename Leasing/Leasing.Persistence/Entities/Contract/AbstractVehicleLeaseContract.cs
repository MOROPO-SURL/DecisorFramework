namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    public abstract class AbstractVehicleLeaseContract : AbstractLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleId))]
        public Domain.Persistence.Entities.Vehicle Vehicle { get; set; }
        public System.Guid VehicleId { get; set; }
    }
}