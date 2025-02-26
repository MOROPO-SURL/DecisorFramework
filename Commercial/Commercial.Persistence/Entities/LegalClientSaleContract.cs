namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalClientSaleContract : Contract.AbstractSaleContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public LegalClient Client { get; set; }
        public System.Guid ClientId { get; set; }
    }
}

