namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeasePersonPostulation : Contract.AbstractLeasePersonPostulation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OfferId))]
        public PropertyLeaseOffer Offer { get; set; }
        public System.Guid OfferId { get; set; }

        public System.Collections.Generic.List<PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge> PropertySpaceBridges { get; set; } = new System.Collections.Generic.List<PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge>();

        public System.Collections.Generic.List<PropertyLeasePersonPostulationDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<PropertyLeasePersonPostulationDocumentBridge>();
    }
}