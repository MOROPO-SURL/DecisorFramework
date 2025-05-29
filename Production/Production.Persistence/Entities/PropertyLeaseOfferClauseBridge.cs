namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class PropertyLeaseOfferClauseBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<PropertyLeaseOffer, System.Guid, Legal.Persistence.Entities.Clause, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PropertyLeaseOffer Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Legal.Persistence.Entities.Clause Stern { get; set; }
    }
}
