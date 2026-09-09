using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public sealed class ResearchSampleInputModel : Contract.AbstractSampleInputModel<ResearchSample>
    {
        public System.Guid ProjectId { get; set; }

        public System.Guid ResearcherId { get; set; }

        public override ResearchSample Export()
        {
            var entity = new ResearchSample { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(ResearchSample entity)
        {
            base.Mergue(entity);

            if (entity.ProjectId != ProjectId)
            {
                entity.Project = null;
                entity.ProjectId = ProjectId;
            }

            if (entity.ResearcherId != ResearcherId)
            {
                entity.Researcher = null;
                entity.ResearcherId = ResearcherId;
            }
        }
    }
}
