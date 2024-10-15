namespace MOROPO.Framework.Decisor.Essential.Persistence.Entities
{
    public class BankAccount : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
	{
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BranchId))]
        public BankBranch Branch { get; set; }
        public System.Guid BranchId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string Number { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Holder { get; set; }
    }
}

