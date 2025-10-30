namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseOrderNaturalProviderBudgetBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchaseOrder, System.Guid, NaturalProviderBudget, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchaseOrder Prow { get; set; }

        public System.Guid SternId { get; set; }
        public NaturalProviderBudget Stern { get; set; }
    }
}
