namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeaseOrganizationPostulation : Contract.AbstractLeaseOrganizationPostulation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OfferId))]
        public PropertyLeaseOffer Offer { get; set; }
        public System.Guid OfferId { get; set; }

        public System.Collections.Generic.ICollection<PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge> PropertySpaceBridges { get; set; }

        public System.Collections.Generic.ICollection<PropertyLeaseOrganizationPostulationDocumentBridge> DocumentBridges { get; set; }
    }
}
