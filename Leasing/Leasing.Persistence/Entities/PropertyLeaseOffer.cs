using MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeaseOffer : AbstractLeaseOffer
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyId))]
        public Domain.Persistence.Entities.Property Property { get; set; }
        public System.Guid PropertyId { get; set; }

        public System.Collections.Generic.ICollection<PropertyLeaseOrganizationPostulation> OrganizationPostulations { get; set; }

        public System.Collections.Generic.ICollection<PropertyLeasePersonPostulation> PersonPostulations { get; set; }

        public System.Collections.Generic.List<PropertyLeaseOfferClauseBridge> ClauseBridges { get; set; }
    }
}
