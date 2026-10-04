namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators
{
    public class AnalysisQualityCheckIsoStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.AnalysisQualityCheckIsoStandardBridge, Entities.AnalysisQualityCheck, System.Guid, Quality.Persistence.Entities.IsoStandard, System.Guid>
    {
        public AnalysisQualityCheckIsoStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.IsoStandardBridge;
        }
    }
}