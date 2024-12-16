namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class VehicleCategory : Guama.Core.Persistence.Entities.Contract.INamedEntity<int>, Core.Persistence.Entities.Contract.IFullFeatureEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public VehicleCategory Parent { get; set; }
        public int? ParentId { get; set; }

        public string Description { get; set; }
    }
}
