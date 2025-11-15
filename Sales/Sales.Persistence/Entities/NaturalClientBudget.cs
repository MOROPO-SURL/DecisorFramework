namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
    public class NaturalClientBudget : Commercial.Persistence.Entities.Contract.AbstractBudget
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid ClientId { get; set; }

        public System.Collections.Generic.List<NaturalClientBudgetServiceBridge> ServiceBridges { get; set; } = new System.Collections.Generic.List<NaturalClientBudgetServiceBridge>();

        public System.Collections.Generic.List<NaturalClientBudgetProductBridge> ProductBridges { get; set; } = new System.Collections.Generic.List<NaturalClientBudgetProductBridge>();
    }
}