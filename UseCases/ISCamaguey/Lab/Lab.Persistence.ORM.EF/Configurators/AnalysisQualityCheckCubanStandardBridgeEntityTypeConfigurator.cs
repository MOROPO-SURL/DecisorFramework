namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators
{
    public class AnalysisQualityCheckCubanStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.AnalysisQualityCheckCubanStandardBridge, Entities.AnalysisQualityCheck, System.Guid, Quality.Persistence.Entities.CubanStandard, System.Guid>
    {
        public AnalysisQualityCheckCubanStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.CubanStandardBridge;
        }
    }
}