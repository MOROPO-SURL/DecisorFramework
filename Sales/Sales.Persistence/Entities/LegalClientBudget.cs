namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
    public class LegalClientBudget : Commercial.Persistence.Entities.Contract.AbstractBudget
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid ClientId { get; set; }

        public System.Collections.Generic.List<LegalClientBudgetServiceBridge> ServiceBridges { get; set; } = new System.Collections.Generic.List<LegalClientBudgetServiceBridge>();

        public System.Collections.Generic.List<LegalClientBudgetProductBridge> ProductBridges { get; set; } = new System.Collections.Generic.List<LegalClientBudgetProductBridge>();
    }
}

