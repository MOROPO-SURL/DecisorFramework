namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class PropertyLeaseOfferPersonContactBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PropertyLeaseOffer, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PropertyLeaseOffer Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.PersonContact Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CredentialDocumentId))]
        public Guama.Media.Persistence.Entities.Document CredentialDocument { get; set; }
        public System.Guid? CredentialDocumentId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public Domain.Persistence.Entities.NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid BusinessKindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }
    }
}