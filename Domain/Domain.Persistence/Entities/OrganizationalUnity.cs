namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class OrganizationalUnity : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Reference { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public OrganizationalUnity Parent { get; set; }
        public System.Guid? ParentId { get; set; }
    }
}
