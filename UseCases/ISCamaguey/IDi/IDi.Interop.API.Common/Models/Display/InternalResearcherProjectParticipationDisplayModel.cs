namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public sealed class InternalResearcherProjectParticipationDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.InternalResearcherProjectParticipation, System.Guid>
    {
        public System.Guid Id { get; set; }

        public InternalResearcherDisplayModel Researcher { get; set; }

        public int TimeAvailability { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public void Import(Persistence.Entities.InternalResearcherProjectParticipation entity)
        {
            Id = entity.Id;
            TimeAvailability = entity.TimeAvailability;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;

            if (entity.Researcher != null)
            {
                Researcher = new InternalResearcherDisplayModel();

                Researcher.Import(entity.Researcher);
            }
        }
    }
}
