namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract
{
    public abstract class AbstractBudget
    {
        public int Number { get; set; }

        public int Year { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime? SharedAt { get; set; }

        public System.DateTime? ConfirmedAt { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CommercialId))]
        public Domain.Persistence.Entities.Employee Commercial { get; set; }
        public System.Guid CommercialId { get; set; }

        public System.Collections.Generic.List<BudgetServiceBridge> ServiceBridges { get; set; } = new System.Collections.Generic.List<BudgetServiceBridge>();

        public System.Collections.Generic.List<BudgetProductBridge> ProductBridges { get; set; } = new System.Collections.Generic.List<BudgetProductBridge>();
    }
}

