namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientVehicleLeaseContract : Contract.AbstractPropertyLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PostulationId))]
        public VehicleLeasePersonPostulation Postulation { get; set; }
        public System.Guid PostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid ClientId { get; set; }
    }
}
