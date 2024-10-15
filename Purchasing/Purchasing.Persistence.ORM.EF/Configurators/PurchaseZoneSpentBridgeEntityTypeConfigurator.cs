namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseZoneSpentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseZoneSpentBridge, Entities.PurchaseZone, System.Guid, Entities.PurchaseSpent, System.Guid>
    {
        public PurchaseZoneSpentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.SpentBridges;
        }
    }
}
