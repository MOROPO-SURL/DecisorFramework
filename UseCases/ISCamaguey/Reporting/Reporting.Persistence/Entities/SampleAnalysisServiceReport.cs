namespace MOROPO.ISCamaguey.Decisor.Reporting.Persistence.Entities
{
    public class SampleAnalysisServiceReport : Contract.AbstractReport
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder Order { get; set; }
        public long OrderId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisReportId))]
        public SampleAnalysisReport SampleAnalysisReport { get; set; }
        public System.Guid SampleAnalysisReportId { get; set; }
    }
}
