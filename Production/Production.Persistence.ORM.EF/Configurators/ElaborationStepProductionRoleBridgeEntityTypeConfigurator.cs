using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ElaborationStepProductionRoleBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ElaborationStepProductionRoleBridge, ElaborationStep, System.Guid, ProductionRole, System.Guid>
    {
        public ElaborationStepProductionRoleBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProductionRoleBridges;
        }
    }
}
