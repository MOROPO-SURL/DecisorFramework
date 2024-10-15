namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class LegalProviderPurchaseZoneBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalProviderPurchaseZoneBridge, Entities.LegalProvider, System.Guid, Entities.PurchaseZone, System.Guid>
    {
        public LegalProviderPurchaseZoneBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ZoneBridges;
            sternNavigationExpression = entity => entity.LegalProviderBridges;
        }
    }
}
