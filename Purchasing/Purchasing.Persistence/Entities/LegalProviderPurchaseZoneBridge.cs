namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class LegalProviderPurchaseZoneBridge : Guama.Core.Persistence.Entities.Contract.IBridge<LegalProvider, System.Guid, PurchaseZone, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public LegalProvider Prow { get; set; }

        public System.Guid SternId { get; set; }
        public PurchaseZone Stern { get; set; }
    }
}
