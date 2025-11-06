namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseOrderPlannedProductSpent : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public PurchaseOrder Order { get; set; }
        public System.Guid OrderId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductId))]
        public Inventory.Persistence.Entities.Product Product { get; set; }
        public System.Guid ProductId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClassificationId))]
        public Inventory.Persistence.Entities.Classification Classification { get; set; }
        public System.Guid? ClassificationId { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public Domain.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }
    }
}