namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class NaturalProviderPurchaseZoneBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalProvider, System.Guid, PurchaseZone, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public NaturalProvider Prow { get; set; }

        public System.Guid SternId { get; set; }
        public PurchaseZone Stern { get; set; }
    }
}
