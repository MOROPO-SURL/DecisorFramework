namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseReceptionProductWeightBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchaseReception, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchaseReception Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Inventory.Persistence.Entities.Product Stern { get; set; }

        public decimal Amount { get; set; }

        public decimal Decrease { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CostCenterId))]
        public Financial.Persistence.Entities.CostCenter CostCenter { get; set; }
        public System.Guid CostCenterId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WarehouseId))]
        public Inventory.Persistence.Entities.Warehouse Warehouse { get; set; }
        public System.Guid WarehouseId { get; set; }
    }
}
