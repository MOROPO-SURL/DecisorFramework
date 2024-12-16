namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalProviderPurchasingContract : Legal.Persistence.Entities.Contract.AbstractContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProviderId))]
        public NaturalProvider Provider { get; set; }
        public System.Guid ProviderId { get; set; }
    }
}

