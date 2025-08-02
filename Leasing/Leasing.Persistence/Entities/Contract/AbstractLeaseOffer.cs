namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractLeaseOffer : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime? OpenAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public HumanResources.Persistence.Entities.Employee Author { get; set; }
        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DecisorId))]
        public HumanResources.Persistence.Entities.Employee Decisor { get; set; }
        public System.Guid? DecisorId { get; set; }

        public string ApprovationReference { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public string Description { get; set; }
    }
}
