namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeaseOfferSpaceSpecification : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OfferId))]
        public PropertyLeaseOffer Offer { get; set; }
        public System.Guid OfferId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SpaceId))]
        public Domain.Persistence.Entities.PropertySpace Space { get; set; }
        public System.Guid SpaceId { get; set; }

        public decimal BaselineAmount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BaselineCurrencyId))]
        public Financial.Persistence.Entities.Currency BaselineCurrency { get; set; }
        public System.Guid BaselineCurrencyId { get; set; }

        public System.Collections.Generic.List<PropertyLeaseOfferSpaceSpecificationClauseBridge> ClauseBridges { get; set; }
    }
}
