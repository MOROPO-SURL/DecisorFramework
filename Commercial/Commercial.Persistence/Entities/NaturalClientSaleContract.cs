namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalClientSaleContract : Contract.AbstractSaleContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public NaturalClient Client { get; set; }
        public System.Guid ClientId { get; set; }
    }
}
