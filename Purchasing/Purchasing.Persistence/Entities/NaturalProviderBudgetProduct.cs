namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class NaturalProviderBudgetProduct : Contract.AbstractProviderBudgetProduct
    {
        public System.Guid BudgetId { get; set; }
        public NaturalProviderBudget Budget { get; set; }
    }
}
