namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientVehicleLeaseContract : Contract.AbstractLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PostulationId))]
        public VehicleLeaseOrganizationPostulation Postulation { get; set; }
        public System.Guid PostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid ClientId { get; set; }
    }
}
