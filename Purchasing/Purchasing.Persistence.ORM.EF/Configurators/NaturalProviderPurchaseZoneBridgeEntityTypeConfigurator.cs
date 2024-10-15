using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class NaturalProviderPurchaseZoneBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<NaturalProviderPurchaseZoneBridge, NaturalProvider, System.Guid, PurchaseZone, System.Guid>
    {
        public NaturalProviderPurchaseZoneBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ZoneBridges;
            sternNavigationExpression = entity => entity.NaturalProviderBridges;
        }
    }
}
