namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class LegalClientWholesaleSale : Contract.AbstractWholesaleSale
	{
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LegalClientSaleContractId))]
		public Commercial.Persistence.Entities.LegalClientSaleContract Contract { get; set; }
		public System.Guid LegalClientSaleContractId { get; set; }
	}
}

