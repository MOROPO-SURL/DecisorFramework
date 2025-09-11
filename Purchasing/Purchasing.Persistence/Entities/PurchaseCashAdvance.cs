namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseCashAdvance : Financial.Persistence.Entities.Contract.AbstractCashAdvance
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PurchasePlanId))]
        public PurchasePlan PurchasePlan { get; set; }
        public System.Guid? PurchasePlanId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public Domain.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }
    }
}
