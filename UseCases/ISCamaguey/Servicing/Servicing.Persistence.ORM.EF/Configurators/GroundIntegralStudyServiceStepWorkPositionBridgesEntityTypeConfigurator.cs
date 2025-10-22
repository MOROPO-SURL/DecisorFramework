namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class GroundIntegralStudyServiceStepWorkPositionBridgesEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.GroundIntegralStudyServiceStepWorkPositionBridge, Entities.GroundIntegralStudyServiceStep, System.Guid, Framework.Decisor.HumanResources.Persistence.Entities.WorkPosition, System.Guid>
    {
        public GroundIntegralStudyServiceStepWorkPositionBridgesEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.WorkPositionBridges;
        }
    }
}
