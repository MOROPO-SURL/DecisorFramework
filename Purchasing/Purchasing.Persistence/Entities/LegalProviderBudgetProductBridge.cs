namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class LegalProviderBudgetProductBridge : Guama.Core.Persistence.Entities.Contract.IBridge<LegalProviderBudget, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public LegalProviderBudget Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Inventory.Persistence.Entities.Product Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClassificationId))]
        public Inventory.Persistence.Entities.Classification Classification { get; set; }
        public System.Guid? ClassificationId { get; set; }

        public decimal UnitPrice { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CurrentyId))]
        public Financial.Persistence.Entities.Currency Currenty { get; set; }
        public System.Guid CurrentyId { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public Domain.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }
    }
}

