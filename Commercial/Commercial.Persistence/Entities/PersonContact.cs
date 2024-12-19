namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class PersonContact : Contract.AbstractContact
    {
        public Guama.Identity.Persistence.Entities.PersonIdentity Identity { get; set; }
        public System.Guid IdentityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid? BusinessKindId { get; set; }
    }
}
