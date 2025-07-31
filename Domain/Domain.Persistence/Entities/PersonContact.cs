namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class PersonContact : Contract.AbstractContact
    {
        public Guama.Identity.Persistence.Entities.PersonIdentity Identity { get; set; }
        public System.Guid IdentityId { get; set; }

        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]{11}$")]
        public string PersonalIdentificationNumber { get; set; }

        public Guama.Security.Personal.Persistence.Entities.User User { get; set; }
        public string UserId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid? BusinessKindId { get; set; }
    }
}