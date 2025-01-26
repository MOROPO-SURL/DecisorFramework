namespace MOROPO.Framework.Decisor.Financial.Persistence.Entities
{
    public class BankDebitCard : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]{16}$")]
        public string Number { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BankAccountId))]
        public BankAccount BankAccount { get; set; }
        public System.Guid BankAccountId { get; set; }

        public System.DateTime ExpireOn { get; set; }
    }
}
