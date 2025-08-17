namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeaseOrganizationPostulation : Contract.AbstractLeaseOrganizationPostulation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OfferId))]
        public PropertyLeaseOffer Offer { get; set; }
        public System.Guid OfferId { get; set; }

        public System.Collections.Generic.List<PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge> PropertySpaceBridges { get; set; } = new System.Collections.Generic.List<PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge>();

        public System.Collections.Generic.List<PropertyLeaseOrganizationPostulationDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<PropertyLeaseOrganizationPostulationDocumentBridge>();
    }
}
