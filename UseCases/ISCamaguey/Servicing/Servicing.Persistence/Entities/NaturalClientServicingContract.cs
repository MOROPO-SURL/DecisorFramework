namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class NaturalClientServicingContract : Contract.AbstractServicingContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ServicingNaturalClientId))]
        public Framework.Decisor.Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid ServicingNaturalClientId { get; set; }
    }
}
