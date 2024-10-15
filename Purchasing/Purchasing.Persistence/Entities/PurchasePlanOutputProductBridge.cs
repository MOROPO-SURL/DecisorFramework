namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchasePlanOutputProductBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchasePlan, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchasePlan Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Inventory.Persistence.Entities.Product Stern { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public Essential.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }
    }
}
