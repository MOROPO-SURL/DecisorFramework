namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class LegalClientServicingContract : Contract.AbstractServicingContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ServicingLegalClientId))]
        public Framework.Decisor.Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid ServicingLegalClientId { get; set; }
    }
}
