namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class VehicleLeasePersonPostulation : Contract.AbstractLeasePersonPostulation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OfferId))]
        public VehicleLeaseOffer Offer { get; set; }
        public System.Guid OfferId { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeasePersonPostulationDocumentBridge> DocumentBridges { get; set; }
    }
}
