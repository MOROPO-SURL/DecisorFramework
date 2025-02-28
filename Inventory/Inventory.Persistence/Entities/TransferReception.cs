namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class TransferReception : Contract.AbstractReception
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WarehouseId))]
        public Warehouse Warehouse { get; set; }
        public System.Guid WarehouseId { get; set; }
    }
}