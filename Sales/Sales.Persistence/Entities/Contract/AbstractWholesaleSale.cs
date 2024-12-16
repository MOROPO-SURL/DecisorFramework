namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities.Contract
{
    public abstract class AbstractWholesaleSale : AbstractSale
    {
        public Commercial.Persistence.Entities.Contract.AbstractBudget Budget { get; set; }
        public int BudgetNumber { get; set; }
        public int BudgetYear { get; set; }
    }
}

