namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public sealed class NaturalClientTrainingServiceExecution : Contract.AbstractExecution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public NaturalClientTrainingServiceOrder Order { get; set; }
        public long OrderId { get; set; }
    }
}
