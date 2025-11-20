namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
    public class NaturalClientBudgetProductBridge
    {
        public int BudgetNumber { get; set; }
        public int BudgetYear { get; set; }
        public System.Guid ClientId { get; set; }
        public NaturalClientBudget Budget { get; set; }

        public System.Guid ProductId { get; set; }
        public Inventory.Persistence.Entities.Product Product { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClassificationId))]
        public Inventory.Persistence.Entities.Classification Classification { get; set; }
        public System.Guid? ClassificationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public Domain.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }
    }
}
