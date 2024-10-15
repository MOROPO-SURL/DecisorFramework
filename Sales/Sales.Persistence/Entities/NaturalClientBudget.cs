namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class NaturalClientBudget : Contract.AbstractBudget
	{
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
		public NaturalClient Client { get; set; }
		public System.Guid? ClientId { get; set; }
	}
}

