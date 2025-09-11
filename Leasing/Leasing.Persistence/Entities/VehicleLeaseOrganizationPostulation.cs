namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class VehicleLeaseOrganizationPostulation : Contract.AbstractLeaseOrganizationPostulation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OfferId))]
        public VehicleLeaseOffer Offer { get; set; }
        public System.Guid OfferId { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeaseOrganizationPostulationDocumentBridge> DocumentBridges { get; set; }
    }
}
