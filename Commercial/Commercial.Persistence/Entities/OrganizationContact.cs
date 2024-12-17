namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class OrganizationContact : Contract.AbstractContact
    {
        public Guama.Identity.Persistence.Entities.OrganizationIdentity Identity { get; set; }
        public System.Guid IdentityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public LegalBusinessKind BusinessKind { get; set; }
        public System.Guid BusinessKindId { get; set; }
    }
}
