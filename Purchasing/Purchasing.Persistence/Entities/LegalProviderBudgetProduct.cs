namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class LegalProviderBudgetProduct : Contract.AbstractProviderBudgetProduct
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BudgetId))]
        public LegalProviderBudget Budget { get; set; }
        public System.Guid BudgetId { get; set; }
    }
}

