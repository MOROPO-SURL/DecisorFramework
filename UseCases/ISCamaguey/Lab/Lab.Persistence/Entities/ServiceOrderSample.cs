namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class ServiceOrderSample : Contract.AbstractSample
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ServiceOrderId))]
        public Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder ServiceOrder { get; set; }
        public long ServiceOrderId { get; set; }
    }
}
