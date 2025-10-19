namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class SampleAnalysisServiceStepWorkPositionBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.SampleAnalysisServiceStepWorkPositionBridge, Entities.SampleAnalysisServiceStep, System.Guid, Framework.Decisor.HumanResources.Persistence.Entities.WorkPosition, System.Guid>
    {
        public SampleAnalysisServiceStepWorkPositionBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.WorkPositionBridges;
        }
    }
}
