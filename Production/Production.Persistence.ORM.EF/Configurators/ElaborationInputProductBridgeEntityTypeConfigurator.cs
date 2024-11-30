using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ElaborationInputProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ElaborationInputProductBridge, Elaboration, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public ElaborationInputProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InputProductBridges;
        }
    }
}
