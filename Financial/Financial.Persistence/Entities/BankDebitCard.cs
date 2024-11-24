namespace MOROPO.Framework.Decisor.Financial.Persistence.Entities
{
    public class BankDebitCard : Core.Persistence.Entities.Contract.IFullFeatureEntity<string>
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.RegularExpression("{0-9}*16")]
        public string Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BankAccountId))]
        public BankAccount BankAccount { get; set; }
        public System.Guid BankAccountId { get; set; }

        public System.DateTime ExpireOn { get; set; }
    }
}
