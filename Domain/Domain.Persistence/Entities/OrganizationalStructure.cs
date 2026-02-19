namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class OrganizationalStructure : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RootStructuringUnitId))]
        public OrganizationalStructuringUnit RootStructuringUnit { get; set; }
        public System.Guid RootStructuringUnitId { get; set;}
    }
}
