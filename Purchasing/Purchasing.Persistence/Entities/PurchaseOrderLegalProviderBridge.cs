namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseOrderLegalProviderBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchaseOrder, System.Guid, Commercial.Persistence.Entities.LegalProvider, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchaseOrder Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Commercial.Persistence.Entities.LegalProvider Stern { get; set; }

        public decimal Debt { get; set; }
    }
}
