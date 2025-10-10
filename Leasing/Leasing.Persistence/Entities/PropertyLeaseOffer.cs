namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeaseOffer : Contract.AbstractLeaseOffer
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropousalId))]
        public PropertyLeasePropousal Propousal { get; set; }
        public System.Guid PropousalId { get; set; }

        public System.Collections.Generic.ICollection<PropertyLeaseOrganizationPostulation> OrganizationPostulations { get; set; }

        public System.Collections.Generic.ICollection<PropertyLeasePersonPostulation> PersonPostulations { get; set; }

        public System.Collections.Generic.List<PropertyLeaseOfferClauseBridge> ClauseBridges { get; set; }
    }
}
