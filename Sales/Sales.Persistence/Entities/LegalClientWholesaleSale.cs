namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class LegalClientWholesaleSale : Contract.AbstractWholesaleSale
	{
		public LegalClientSaleContract Contract { get; set; }
		public int? ContractNumber { get; set; }
		public int? ContractYear { get; set; }
	}
}

