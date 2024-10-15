namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class LegalClientSaleContract : Essential.Persistence.Entities.Contract.AbstractContract
    {
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
		public LegalClient Client { get; set; }
		public System.Guid ClientId { get; set; }
	}
}

