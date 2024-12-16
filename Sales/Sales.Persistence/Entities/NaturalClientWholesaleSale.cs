namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class NaturalClientWholesaleSale : Contract.AbstractWholesaleSale
    {
        public Commercial.Persistence.Entities.NaturalClientSaleContract Contract { get; set; }
        public int? ContractNumber { get; set; }
        public int? ContractYear { get; set; }
    }
}

