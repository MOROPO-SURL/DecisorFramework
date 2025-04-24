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
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProyectionMonthlyClosure> MonthlyClosures { get; set; }

        public ICollection<ProyectionOrganizationResponsabilityBridge> OrganizationResponsablityBridges { get; set; }

        public ICollection<ProyectionOrganizationParticipationBridge> OrganizationParticipationBridges { get; set; }

        public ICollection<ProyectionGuidelineBridge> GuidelineBridges { get; set; }
    }
}
