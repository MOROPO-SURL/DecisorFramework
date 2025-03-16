namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract
{
    public abstract class AbstractLegalRelationship : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public Domain.Persistence.Entities.OrganizationContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RepresentativeId))]
        public Domain.Persistence.Entities.PersonContact Representative { get; set; }
        public System.Guid RepresentativeId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(MainPostalContactId))]
        public Guama.Identity.Persistence.Entities.PostalContactItem MainPostalContact { get; set; }
        public System.Guid MainPostalContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DefaultPaymentTermId))]
        public PaymentTerm DefaultPaymentTerm { get; set; }
        public System.Guid DefaultPaymentTermId { get; set; }
    }
}

