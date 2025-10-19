namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class TrainingServiceStepWorkPositionBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.TrainingServiceStepWorkPositionBridge, Entities.TrainingServiceStep, System.Guid, Framework.Decisor.HumanResources.Persistence.Entities.WorkPosition, System.Guid>
    {
        public TrainingServiceStepWorkPositionBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.WorkPositionBridges;
        }
    }
}
