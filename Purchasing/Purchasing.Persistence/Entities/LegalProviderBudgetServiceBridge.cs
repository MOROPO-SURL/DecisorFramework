namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class LegalProviderBudgetServiceBridge : Guama.Core.Persistence.Entities.Contract.IBridge<LegalProviderBudget, System.Guid, Commercial.Persistence.Entities.RequestableService, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public LegalProviderBudget Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Commercial.Persistence.Entities.RequestableService Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CurrentyId))]
        public Financial.Persistence.Entities.Currency Currenty { get; set; }
        public System.Guid CurrentyId { get; set; }

        public int Count { get; set; }
    }
}

