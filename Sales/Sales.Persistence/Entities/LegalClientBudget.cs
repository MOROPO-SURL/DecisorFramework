namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class LegalClientBudget : Contract.AbstractBudget
	{
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
		public LegalClient Client { get; set; }
		public System.Guid? ClientId { get; set; }
	}
}

