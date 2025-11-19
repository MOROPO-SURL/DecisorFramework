namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
	public class NaturalClientWholesaleSale : Contract.AbstractWholesaleSale
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(NaturalClientSaleContractId))]
        public Commercial.Persistence.Entities.NaturalClientSaleContract Contract { get; set; }
        public System.Guid NaturalClientSaleContractId { get; set; }
    }
}

