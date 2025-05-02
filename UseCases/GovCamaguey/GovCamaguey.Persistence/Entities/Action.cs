using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;
using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class Action : INamedEntity<System.Guid>, IArchivableEntity<System.Guid>, IEnableableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProyectionId))]
        public Proyection Proyection { get; set; }
        public System.Guid ProyectionId { get; set; }

        public ICollection<ActionMonthlyClosure> MonthlyClosures { get; set; }

        public ICollection<ActionOrganizationResponsabilityBridge> OrganizationResponsabilityBridges { get; set; } = new List<ActionOrganizationResponsabilityBridge>();

        public ICollection<ActionOrganizationParticipationBridge> OrganizationParticipationBridges { get; set; } = new List<ActionOrganizationParticipationBridge>();

        public ICollection<Indicator> Indicators { get; set; } = new List<Indicator>();
    }
}
