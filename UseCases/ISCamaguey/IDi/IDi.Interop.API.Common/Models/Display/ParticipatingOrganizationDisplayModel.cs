using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ParticipatingOrganizationDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ParticipatingOrganization, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel[] KnowledgeAreas { get; set; }

        public void Import(Persistence.Entities.ParticipatingOrganization entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            KnowledgeAreas = entity.KnowledgeAreaBridges.OrderBy(bridge => bridge.Stern.Priority).Select(bridge =>
            {
                var model = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.Contact != null)
            {
                Contact = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                Contact.Import(entity.Contact);
            }
        }
    }
}
