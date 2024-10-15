namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchasePlanDeparture : Inventory.Persistence.Entities.Contract.AbstractDeparture
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PurchasePlanId))]
        public PurchasePlan PurchasePlan { get; set; }
        public System.Guid? PurchasePlanId { get; set; }
    }
}
