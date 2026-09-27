namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public sealed class LegalClientGroundIntegralStudyServiceExecution : Contract.AbstractExecution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public LegalClientGroundIntegralStudyServiceOrder Order { get; set; }
        public long OrderId { get; set; }
    }
}
