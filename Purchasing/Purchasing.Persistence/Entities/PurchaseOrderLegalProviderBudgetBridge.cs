namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseOrderLegalProviderBudgetBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchaseOrder, System.Guid, LegalProviderBudget, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchaseOrder Prow { get; set; }

        public System.Guid SternId { get; set; }
        public LegalProviderBudget Stern { get; set; }
    }
}
