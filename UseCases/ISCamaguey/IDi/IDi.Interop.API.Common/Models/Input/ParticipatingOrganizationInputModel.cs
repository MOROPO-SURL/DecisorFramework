using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ParticipatingOrganizationInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.ParticipatingOrganization, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid ContactId { get; set; }

        public System.Collections.Generic.List<Display.ResearchAreaDisplayModel> ResearchAreas { get; set; } = new System.Collections.Generic.List<Display.ResearchAreaDisplayModel>();

        public Persistence.Entities.ParticipatingOrganization Export()
        {
            var entity = new Persistence.Entities.ParticipatingOrganization { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.ParticipatingOrganization entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.ParticipatingOrganization entity)
        {
            entity.Priority = Priority;

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }

            entity.ResearchAreaBridges.Clear();
            entity.ResearchAreaBridges = ResearchAreas.Select(model => new Persistence.Entities.ParticipatingOrganizationResearchAreaBridge { ProwId = entity.Id, SternId = model.Id }).ToList();
        }
    }
}
