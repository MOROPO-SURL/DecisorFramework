namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractLeaseOrganizationPostulation : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.OrganizationContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }
    }
}
