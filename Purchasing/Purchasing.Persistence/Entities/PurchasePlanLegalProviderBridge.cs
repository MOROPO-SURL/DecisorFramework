namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchasePlanLegalProviderBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchasePlan, System.Guid, LegalProvider, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchasePlan Prow { get; set; }

        public System.Guid SternId { get; set; }
        public LegalProvider Stern { get; set; }

        public decimal Debt { get; set; }
    }
}
