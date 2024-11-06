namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class Batch : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public string ExternalReference { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WarehouseId))]
        public Warehouse Warehouse { get; set; }
        public System.Guid WarehouseId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public System.Guid ProductId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClassificationId))]
        public Classification Classification { get; set; }
        public System.Guid? ClassificationId { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ReceptionId))]
        public Contract.AbstractReception Reception { get; set; }
        public System.Guid ReceptionId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CostCenterId))]
        public Financial.Persistence.Entities.CostCenter CostCenter { get; set; }
        public System.Guid CostCenterId { get; set; }
    }
}
