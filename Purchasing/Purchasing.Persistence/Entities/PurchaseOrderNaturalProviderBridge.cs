namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseOrderNaturalProviderBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchaseOrder, System.Guid, Commercial.Persistence.Entities.NaturalProvider, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchaseOrder Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Commercial.Persistence.Entities.NaturalProvider Stern { get; set; }

        public decimal Debt { get; set; }
    }
}
