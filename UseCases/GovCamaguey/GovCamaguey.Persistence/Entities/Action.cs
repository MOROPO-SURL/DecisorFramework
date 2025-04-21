using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class Action : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
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

        public ICollection<ActionMonthlyClosure> MonthlyClosures { get; set; }

        public ICollection<ActionOrganizationResponsabilityBridge> OrganizationResponsablityBridges { get; set; }

        public ICollection<ActionOrganizationParticipationBridge> OrganizationParticipationBridges { get; set; }

        public ICollection<Indicator> Indicators { get; set; }
    }
}
