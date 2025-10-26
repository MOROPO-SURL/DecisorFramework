namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class OrganizationContact : Contract.AbstractContact
    {
        public Guama.Identity.Persistence.Entities.OrganizationIdentity Identity { get; set; }
        public System.Guid IdentityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public LegalBusinessKind BusinessKind { get; set; }
        public System.Guid BusinessKindId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CentralStateStructureId))]
        public CentralStateStructure CentralStateStructure { get; set; }
        public System.Guid? CentralStateStructureId { get; set; }

        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RepresentativeId))]
        public PersonContact Representative { get; set; }
        public System.Guid? RepresentativeId { get; set; }
    }
}
