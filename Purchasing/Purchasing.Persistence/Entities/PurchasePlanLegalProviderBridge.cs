namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchasePlanLegalProviderBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchasePlan, System.Guid, Commercial.Persistence.Entities.LegalProvider, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchasePlan Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Commercial.Persistence.Entities.LegalProvider Stern { get; set; }

        public decimal Debt { get; set; }
    }
}
