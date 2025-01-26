using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ElaborationOutputProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ElaborationOutputProductBridge, Elaboration, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public ElaborationOutputProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.OutputProductBridges;
        }
    }
}
