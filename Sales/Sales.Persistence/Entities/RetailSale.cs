namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class RetailSale : Contract.AbstractSale
	{
		public Guama.Identity.Persistence.Entities.PersonIdentity Identity { get; set; }
		public System.Guid? IdentityId { get; set; }
	}
}

