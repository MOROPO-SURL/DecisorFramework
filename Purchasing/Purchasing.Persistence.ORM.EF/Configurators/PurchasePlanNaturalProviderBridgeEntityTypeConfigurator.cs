namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchasePlanNaturalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchasePlanNaturalProviderBridge, Entities.PurchasePlan, System.Guid, Entities.NaturalProvider, System.Guid>
    {
        public PurchasePlanNaturalProviderBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.NaturalProviderBridges;
        }
    }
}
