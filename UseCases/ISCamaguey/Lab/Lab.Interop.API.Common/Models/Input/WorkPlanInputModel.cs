using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public sealed class WorkPlanInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<WorkPlan, System.Guid>
    {
        public System.DateTime At { get; set; }

        public System.Guid WorkingGroupId { get; set; }

        public string Description { get; set; }

        public IEnumerable<System.Guid> InServiceOrderSampleIds { get; set; }
        public IEnumerable<System.Guid> OutServiceOrderSampleIds { get; set; }

        public IEnumerable<System.Guid> InResearchSampleIds { get; set; }
        public IEnumerable<System.Guid> OutResearchSampleIds { get; set; }

        public IEnumerable<System.Guid> InProductionSampleIds { get; set; }
        public IEnumerable<System.Guid> OutProductionSampleIds { get; set; }

        public override WorkPlan Export()
        {
            var entity = new WorkPlan { Id = Id, Archived = false, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(WorkPlan entity)
        {
            entity.At = At;
            entity.Description = Description;

            if (entity.WorkingGroupId != WorkingGroupId)
            {
                entity.WorkingGroup = null;
                entity.WorkingGroupId = WorkingGroupId;
            }
        }
    }
}
