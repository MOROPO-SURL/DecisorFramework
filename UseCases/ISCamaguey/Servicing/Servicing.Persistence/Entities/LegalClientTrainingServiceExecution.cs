namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public sealed class LegalClientTrainingServiceExecution : Contract.AbstractExecution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public LegalClientTrainingServiceOrder Order { get; set; }
        public long OrderId { get; set; }
    }
}
