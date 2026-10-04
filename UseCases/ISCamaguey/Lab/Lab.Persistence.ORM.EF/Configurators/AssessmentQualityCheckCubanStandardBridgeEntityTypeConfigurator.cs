namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators
{
    public class AssessmentQualityCheckCubanStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.AssessmentQualityCheckCubanStandardBridge, Entities.AssessmentQualityCheck, System.Guid, Quality.Persistence.Entities.CubanStandard, System.Guid>
    {
        public AssessmentQualityCheckCubanStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.CubanStandardBridge;
        }
    }
}