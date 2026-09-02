using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class WorkPlan : IArchivableEntity<System.Guid>, IEnableableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }

        public System.DateTime At { get; set; }

        public WorkingGroup WorkingGroup { get; set; }
        public System.Guid WorkingGroupId { get; set; }

        public string Description { get; set; }

        public List<WorkPlanServiceOrderSampleBridge> ServiceOrderSampleBridges { get; set; } = new List<WorkPlanServiceOrderSampleBridge>();

        public List<WorkPlanResearchSampleBridge> ResearchSampleBridges { get; set; } = new List<WorkPlanResearchSampleBridge>();

        public List<WorkPlanProductionSampleBridge> ProductionSampleBridges { get; set; } = new List<WorkPlanProductionSampleBridge>();
    }
}