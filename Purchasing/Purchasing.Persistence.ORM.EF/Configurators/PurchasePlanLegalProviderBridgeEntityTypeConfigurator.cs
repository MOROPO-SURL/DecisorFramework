namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchasePlanLegalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchasePlanLegalProviderBridge, Entities.PurchasePlan, System.Guid, Entities.LegalProvider, System.Guid>
    {
        public PurchasePlanLegalProviderBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.LegalProviderBridges;
        }
    }
}
