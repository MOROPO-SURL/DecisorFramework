namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseZoneLegalProviderBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchaseZone, System.Guid, Commercial.Persistence.Entities.LegalProvider, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchaseZone Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Commercial.Persistence.Entities.LegalProvider Stern { get; set; }
    }
}
