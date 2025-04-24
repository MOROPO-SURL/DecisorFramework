using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class Objective : INamedEntity<System.Guid>, IArchivableEntity<System.Guid>, IEnableableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public Person Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }
    }
}
