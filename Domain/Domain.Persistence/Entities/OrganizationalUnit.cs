namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class OrganizationalUnit : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(200)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(1024)]  
        public string Description { get; set; }
    }
}
