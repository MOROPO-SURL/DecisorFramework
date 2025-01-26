namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class BudgetServiceBridge
    {
        public int BudgetNumber { get; set; }
        public int BudgetYear { get; set; }
        public Contract.AbstractBudget Budget { get; set; }

        public ProvisionableService Service { get; set; }
        public System.Guid ServiceId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int Count { get; set; }
    }
}

