namespace MOROPO.ISCamaguey.Decisor.Reporting.Persistence.Entities
{
    public class SampleAnalysisReport : Contract.AbstractReport
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AnalysisId))]
        public Lab.Persistence.Entities.Analysis Analysis { get; set; }
        public System.Guid AnalysisId { get; set; }
    }
}
