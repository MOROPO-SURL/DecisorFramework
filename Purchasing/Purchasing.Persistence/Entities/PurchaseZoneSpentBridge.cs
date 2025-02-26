namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseZoneSpentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchaseZone, System.Guid, PurchaseSpent, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchaseZone Prow { get; set; }

        public System.Guid SternId { get; set; }
        public PurchaseSpent Stern { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CurrencyId))]
        public Financial.Persistence.Entities.Currency Currency { get; set; }
        public System.Guid CurrencyId { get; set; }
    }
}
