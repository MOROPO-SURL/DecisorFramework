namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
	public class LegalProviderPurchasingContract : Essential.Persistence.Entities.Contract.AbstractContract
    {
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProviderId))]
		public LegalProvider Provider { get; set; }
		public System.Guid ProviderId { get; set; }
	}
}

