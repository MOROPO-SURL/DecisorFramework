namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ElaborationStepWorkPositionBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ElaborationStepWorkPositionBridge, Entities.ElaborationStep, System.Guid, HumanResources.Persistence.Entities.WorkPosition, System.Guid>
    {
        public ElaborationStepWorkPositionBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.WorkPositionBridges;
        }
    }
}
