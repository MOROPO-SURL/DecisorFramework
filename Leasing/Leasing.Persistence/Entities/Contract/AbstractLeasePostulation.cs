namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractLeasePostulation : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BankAccountId))]
        public Financial.Persistence.Entities.BankAccount BankAccount { get; set; }
        public System.Guid BankAccountId { get; set; }
    }
}
