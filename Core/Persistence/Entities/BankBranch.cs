namespace MOROPO.Framework.Decisor.Core.Persistence.Entities
{
    public class BankBranch : Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgencyId))]
        public BankAgency Agency { get; set; }
        public System.Guid AgencyId { get; set; }

        public int Number { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LocationId))]
        public Guama.Identity.Persistence.Entities.PostalContactItem Location { get; set; }
        public System.Guid? LocationId { get; set; }
    }
}

