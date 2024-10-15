using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class Warehouse : INamedEntity<System.Guid>, Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public string Description { get; set; }
    }
}
