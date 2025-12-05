namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseProductNaturalProviderBridge
    {
        public System.Guid PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public System.Guid ProductId { get; set; }
        public Inventory.Persistence.Entities.Product Product { get; set; }

        public System.Guid CostCenterId { get; set; }
        public Financial.Persistence.Entities.CostCenter CostCenter { get; set; }

        public System.Guid ProviderId { get; set; }
        public Commercial.Persistence.Entities.NaturalProvider Provider { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public Domain.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }

        public decimal Cost { get; set; }
    }
}
