namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public sealed class LegalClientSampleAnalysisServiceExecution : Contract.AbstractExecution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public LegalClientSampleAnalysisServiceOrder Order { get; set; }
        public long OrderId { get; set; }
    }
}
