namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseReceptionProductWeightBridge
    {
        public System.Guid ReceptionId { get; set; }
        public PurchaseReception Reception { get; set; }

        public System.Guid ProductId { get; set; }
        public Inventory.Persistence.Entities.Product Product { get; set; }

        public System.Guid CostCenterId { get; set; }
        public Financial.Persistence.Entities.CostCenter CostCenter { get; set; }

        public decimal Amount { get; set; }

        public decimal Decrease { get; set; }
    }
}
