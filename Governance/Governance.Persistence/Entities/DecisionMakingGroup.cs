using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class DecisionMakingGroup : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StructureId))]
        public Domain.Persistence.Entities.Structure Structure { get; set; }
        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeaderId))]
        public Domain.Persistence.Entities.Employee Leader { get; set; }
        public System.Guid LeaderId { get; set; }

        public string Description { get; set; }

        public List<DecisionMakingGroupEmployeeBridge> EmployeeBridges { get; set; } = new List<DecisionMakingGroupEmployeeBridge>();

        public List<DecisionMakingGroupContactBridge> ContactBridges { get; set; } = new List<DecisionMakingGroupContactBridge>();
    }
}
