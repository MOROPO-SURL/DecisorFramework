namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class ServiceOrderCollect : Framework.Decisor.Financial.Persistence.Entities.Contract.AbstractCollect
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public Contract.AbstractServiceOrder Order { get; set; }
        public long OrderId { get; set; }
    }
}
