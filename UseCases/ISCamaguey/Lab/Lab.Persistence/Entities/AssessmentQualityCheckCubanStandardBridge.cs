namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class AssessmentQualityCheckCubanStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<AssessmentQualityCheck, System.Guid, Quality.Persistence.Entities.CubanStandard, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public AssessmentQualityCheck Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public Quality.Persistence.Entities.CubanStandard Stern { get ; set ; }
    }
}