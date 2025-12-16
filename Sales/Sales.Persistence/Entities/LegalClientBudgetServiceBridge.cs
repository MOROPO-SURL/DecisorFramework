namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
    public class LegalClientBudgetServiceBridge
    {
        public int BudgetNumber { get; set; }
        public int BudgetYear { get; set; }
        public System.Guid ClientId { get; set; }
        public LegalClientBudget Budget { get; set; }

        public Commercial.Persistence.Entities.ProvisionableService Service { get; set; }
        public System.Guid ServiceId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int Count { get; set; }
    }
}

