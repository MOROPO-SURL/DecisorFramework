namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientVehicleLeaseContract : Contract.AbstractLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleLeaseNaturalPostulationId))]
        public VehicleLeasePersonPostulation Postulation { get; set; }
        public System.Guid? VehicleLeaseNaturalPostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleLeaseNaturalClientId))]
        public Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid? VehicleLeaseNaturalClientId { get; set; }
    }
}
