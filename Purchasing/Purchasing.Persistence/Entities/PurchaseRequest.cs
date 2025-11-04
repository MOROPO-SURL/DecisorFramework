namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseRequest : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public Domain.Persistence.Entities.Employee Author { get; set; }
        public System.Guid AuthorId { get; set; }

        public System.Collections.Generic.ICollection<PurchaseRequestExpectedProductAdquisition> ExpectedProductAdquisitions { get; set; }
    }
}
