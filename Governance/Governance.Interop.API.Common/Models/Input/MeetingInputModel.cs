namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input
{
    public class MeetingInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Meeting, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid DecisionMakingGroupId { get; set; }

        public System.Guid AuthorId { get; set; }

        public string Summary { get; set; }

        public string Rapporteurship { get; set; }

        public Persistence.Entities.Meeting Export()
        {
            var entity = new Persistence.Entities.Meeting { Id = System.Guid.NewGuid() };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Meeting entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Meeting entity)
        {
            entity.Index = Index;
            entity.At = At;
            entity.Summary = Summary;
            entity.Rapporteurship = Rapporteurship;

            if (entity.DecisionMakingGroupId != DecisionMakingGroupId)
            {
                entity.DecisionMakingGroup = null;
                entity.DecisionMakingGroupId = DecisionMakingGroupId;
            }

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }
        }
    }
}
