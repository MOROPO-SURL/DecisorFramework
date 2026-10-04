namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators
{
    public class AssessmentQualityCheckIsoStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.AssessmentQualityCheckIsoStandardBridge, Entities.AssessmentQualityCheck, System.Guid, Quality.Persistence.Entities.IsoStandard, System.Guid>
    {
        public AssessmentQualityCheckIsoStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.IsoStandardBridge;
        }
    }
}