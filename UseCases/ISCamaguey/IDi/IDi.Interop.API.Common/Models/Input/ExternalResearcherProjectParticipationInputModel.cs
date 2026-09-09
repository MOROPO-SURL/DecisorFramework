using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public sealed class ExternalResearcherProjectParticipationInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ExternalResearcherProjectParticipation, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid ResearcherId { get; set; }

        public int TimeAvailability { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public ExternalResearcherProjectParticipation Export()
        {
            var entity = new ExternalResearcherProjectParticipation { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(ExternalResearcherProjectParticipation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ExternalResearcherProjectParticipation entity)
        {
            entity.TimeAvailability = TimeAvailability;
            entity.StartAt = StartAt;
            entity.EndAt = EndAt;

            if (entity.ResearcherId != ResearcherId)
            {
                entity.Researcher = null;
                entity.ResearcherId = ResearcherId;
            }
        }
    }
}
