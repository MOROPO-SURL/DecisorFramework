namespace MOROPO.Framework.Decisor.Financial.Persistence.Entities
{
    public class CostCenter : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string About { get; set; }
    }
}

