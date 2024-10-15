namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
	public class NaturalProviderPurchasingContract : Essential.Persistence.Entities.Contract.AbstractContract
    {
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProviderId))]
		public NaturalProvider Provider { get; set; }
		public System.Guid ProviderId { get; set; }
	}
}

