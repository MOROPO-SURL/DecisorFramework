namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class LegalClientWholesaleSale : Contract.AbstractWholesaleSale
	{
		public Commercial.Persistence.Entities.LegalClientSaleContract Contract { get; set; }
		public int? ContractNumber { get; set; }
		public int? ContractYear { get; set; }
	}
}

