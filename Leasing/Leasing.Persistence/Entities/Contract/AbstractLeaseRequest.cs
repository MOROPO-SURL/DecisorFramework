namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    public abstract class AbstractLeaseRequest : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public HumanResources.Persistence.Entities.Employee Author { get; set; }
        public System.Guid AuthorId { get; set; }

        public string Description { get; set; }
    }
}
