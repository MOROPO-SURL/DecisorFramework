namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseCashAdvance : Financial.Persistence.Entities.Contract.AbstractCashAdvance
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PurchaseOrderId))]
        public PurchaseOrder PurchaseOrder { get; set; }
        public System.Guid? PurchaseOrderId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public Domain.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }
    }
}
