namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalClientSaleContract : Legal.Persistence.Entities.Contract.AbstractContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public NaturalClient Client { get; set; }
        public System.Guid ClientId { get; set; }
    }
}

