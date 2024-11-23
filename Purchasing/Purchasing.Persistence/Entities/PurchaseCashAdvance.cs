namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseCashAdvance : Financial.Persistence.Entities.Contract.AbstractCashAdvance
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }
        public System.Guid? PurchaseId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public HumanResources.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }
    }
}
