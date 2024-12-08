namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchasePurchaseSpentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Purchase, System.Guid, PurchaseSpent, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Purchase Prow { get; set; }

        public System.Guid SternId { get; set; }
        public PurchaseSpent Stern { get; set; }

        public decimal Amount { get; set; } // Unitario

        public int Count { get; set; }

        public bool IsRegular { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CostCenterId))]
        public Financial.Persistence.Entities.CostCenter CostCenter { get; set; }
        public System.Guid CostCenterId { get; set; }
    }
}