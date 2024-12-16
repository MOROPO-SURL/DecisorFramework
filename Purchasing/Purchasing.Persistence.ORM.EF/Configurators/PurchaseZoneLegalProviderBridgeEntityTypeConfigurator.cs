namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseZoneLegalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseZoneLegalProviderBridge, Entities.PurchaseZone, System.Guid, Commercial.Persistence.Entities.LegalProvider, System.Guid>
    {
        public PurchaseZoneLegalProviderBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.LegalProviderBridges;
        }
    }
}
