using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ElaborationInputProductClassificationBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ElaborationInputProductClassificationBridge, Elaboration, System.Guid, Inventory.Persistence.Entities.Classification, System.Guid>
    {
        public ElaborationInputProductClassificationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InputProductClassificationBridges;
        }
    }
}
