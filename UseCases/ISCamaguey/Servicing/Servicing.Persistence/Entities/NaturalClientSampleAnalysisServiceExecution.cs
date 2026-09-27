namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public sealed class NaturalClientSampleAnalysisServiceExecution : Contract.AbstractExecution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public NaturalClientSampleAnalysisServiceOrder Order { get; set; }
        public long OrderId { get; set; }
    }
}