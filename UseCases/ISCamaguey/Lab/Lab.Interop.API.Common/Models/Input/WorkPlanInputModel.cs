using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public sealed class WorkPlanInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<WorkPlan, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid WorkingGroupId { get; set; }

        public string Description { get; set; }

        public IEnumerable<System.Guid> InServiceOrderSampleIds { get; set; }
        public IEnumerable<System.Guid> OutServiceOrderSampleIds { get; set; }

        public IEnumerable<System.Guid> InResearchSampleIds { get; set; }
        public IEnumerable<System.Guid> OutResearchSampleIds { get; set; }

        public IEnumerable<System.Guid> InProductionSampleIds { get; set; }
        public IEnumerable<System.Guid> OutProductionSampleIds { get; set; }

        public WorkPlan Export()
        {
            var entity = new WorkPlan { Id = Id, Archived = false, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(WorkPlan entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(WorkPlan entity)
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
