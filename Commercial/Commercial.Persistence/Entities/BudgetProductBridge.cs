namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class BudgetProductBridge
    {
        public int BudgetNumber { get; set; }
        public int BudgetYear { get; set; }
        public Contract.AbstractBudget Budget { get; set; }

        public Inventory.Persistence.Entities.Product Product { get; set; }
        public System.Guid ProductId { get; set; }

        public Inventory.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }
    }
}

