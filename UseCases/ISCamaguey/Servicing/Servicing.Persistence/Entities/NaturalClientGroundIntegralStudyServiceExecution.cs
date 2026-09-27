namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public sealed class NaturalClientGroundIntegralStudyServiceExecution : Contract.AbstractExecution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public NaturalClientGroundIntegralStudyServiceOrder Order { get; set; }
        public long OrderId { get; set; }
    }
}
