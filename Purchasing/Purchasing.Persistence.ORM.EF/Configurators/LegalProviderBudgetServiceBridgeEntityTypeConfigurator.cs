namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class LegalProviderBudgetServiceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalProviderBudgetServiceBridge, Entities.LegalProviderBudget, System.Guid, Commercial.Persistence.Entities.RequestableService, System.Guid>
    {
        public LegalProviderBudgetServiceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ServiceBridges;
        }
    }
}