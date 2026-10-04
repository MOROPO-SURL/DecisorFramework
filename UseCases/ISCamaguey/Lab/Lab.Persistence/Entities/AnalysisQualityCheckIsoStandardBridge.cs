namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class AnalysisQualityCheckIsoStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<AnalysisQualityCheck, System.Guid, Quality.Persistence.Entities.IsoStandard, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public AnalysisQualityCheck Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        public Quality.Persistence.Entities.IsoStandard Stern { get; set; }
    }
}