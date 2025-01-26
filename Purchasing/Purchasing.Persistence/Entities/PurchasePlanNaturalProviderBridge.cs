namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchasePlanNaturalProviderBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PurchasePlan, System.Guid, Commercial.Persistence.Entities.NaturalProvider, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PurchasePlan Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Commercial.Persistence.Entities.NaturalProvider Stern { get; set; }

        public decimal Debt { get; set; }
    }
}
