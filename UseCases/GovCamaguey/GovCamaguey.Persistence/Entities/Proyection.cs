using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;
using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class Proyection : INamedEntity<System.Guid>, IArchivableEntity<System.Guid>, IEnableableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(1024)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(5120)]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ObjectiveId))]
        public Objective Objective { get; set; }
        public System.Guid ObjectiveId { get; set; }

        public ICollection<ProyectionMonthlyClosure> MonthlyClosures { get; set; }

        public ICollection<ProyectionOrganizationResponsabilityBridge> OrganizationResponsabilityBridges { get; set; } = new List<ProyectionOrganizationResponsabilityBridge>();

        public ICollection<ProyectionOrganizationParticipationBridge> OrganizationParticipationBridges { get; set; } = new List<ProyectionOrganizationParticipationBridge>();

        public ICollection<ProyectionGuidelineBridge> GuidelineBridges { get; set; } = new List<ProyectionGuidelineBridge>();

        public ICollection<Action> Actions { get; set; } = new List<Action>();

        public ICollection<ProyectionIndicator> Indicators { get; set; } = new List<ProyectionIndicator>();
    }
}
