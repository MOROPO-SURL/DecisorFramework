namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class NaturalClientSaleContract : Essential.Persistence.Entities.Contract.AbstractContract
    {
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
		public NaturalClient Client { get; set; }
		public System.Guid ClientId { get; set; }
	}
}

