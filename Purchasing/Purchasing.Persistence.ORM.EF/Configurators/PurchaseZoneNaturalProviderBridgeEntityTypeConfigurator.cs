namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseZoneNaturalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseZoneNaturalProviderBridge, Entities.PurchaseZone, System.Guid, Commercial.Persistence.Entities.NaturalProvider, System.Guid>
    {
        public PurchaseZoneNaturalProviderBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.NaturalProviderBridges;
        }
    }
}
