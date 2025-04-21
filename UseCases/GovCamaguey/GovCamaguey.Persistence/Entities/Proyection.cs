using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class Proyection : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

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
