namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseReception : Inventory.Persistence.Entities.Contract.AbstractReception
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }
        public System.Guid? PurchaseId { get; set; }

        public System.Collections.Generic.List<PurchaseReceptionProductWeightBridge> ProductWeightBridges { get; set; } = new System.Collections.Generic.List<PurchaseReceptionProductWeightBridge>();
    }
}
