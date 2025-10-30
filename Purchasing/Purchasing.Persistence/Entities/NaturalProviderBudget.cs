namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class NaturalProviderBudget : Commercial.Persistence.Entities.Contract.AbstractBudget
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProviderId))]
        public Commercial.Persistence.Entities.NaturalProvider Provider { get; set; }
        public System.Guid ProviderId { get; set; }

        public System.Collections.Generic.List<NaturalProviderBudgetServiceBridge> ServiceBridges { get; set; } = new System.Collections.Generic.List<NaturalProviderBudgetServiceBridge>();

        public System.Collections.Generic.List<NaturalProviderBudgetProductBridge> ProductBridges { get; set; } = new System.Collections.Generic.List<NaturalProviderBudgetProductBridge>();
    }
}