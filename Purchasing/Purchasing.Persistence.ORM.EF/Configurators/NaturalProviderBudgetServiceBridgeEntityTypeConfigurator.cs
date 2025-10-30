namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class NaturalProviderBudgetServiceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalProviderBudgetServiceBridge, Entities.NaturalProviderBudget, System.Guid, Commercial.Persistence.Entities.RequestableService, System.Guid>
    {
        public NaturalProviderBudgetServiceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ServiceBridges;
        }
    }
}
