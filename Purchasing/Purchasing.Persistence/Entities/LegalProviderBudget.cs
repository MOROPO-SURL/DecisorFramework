namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class LegalProviderBudget : Commercial.Persistence.Entities.Contract.AbstractBudget
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProviderId))]
        public Commercial.Persistence.Entities.LegalProvider Provider { get; set; }
        public System.Guid ProviderId { get; set; }

        public System.Collections.Generic.List<LegalProviderBudgetServiceBridge> ServiceBridges { get; set; } = new System.Collections.Generic.List<LegalProviderBudgetServiceBridge>();

        public System.Collections.Generic.List<LegalProviderBudgetProductBridge> ProductBridges { get; set; } = new System.Collections.Generic.List<LegalProviderBudgetProductBridge>();
    }
}

