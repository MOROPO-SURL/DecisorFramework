namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public sealed class ExternalResearcherProjectParticipationDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ExternalResearcherProjectParticipation, System.Guid>
    {
        public System.Guid Id { get; set; }

        public ExternalResearcherDisplayModel Researcher { get; set; }

        public int TimeAvailability { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public void Import(Persistence.Entities.ExternalResearcherProjectParticipation entity)
        {
            Id = entity.Id;
            TimeAvailability = entity.TimeAvailability;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;

            if (entity.Researcher != null)
            {
                Researcher = new ExternalResearcherDisplayModel();

                Researcher.Import(entity.Researcher);
            }
        }
    }
}
