namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseOrderDeparture : Inventory.Persistence.Entities.Contract.AbstractDeparture
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PurchaseOrderId))]
        public PurchaseOrder PurchaseOrder { get; set; }
        public System.Guid? PurchaseOrderId { get; set; }
    }
}
