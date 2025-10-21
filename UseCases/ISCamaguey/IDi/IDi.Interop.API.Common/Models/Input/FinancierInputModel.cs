using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class FinancierInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Financier, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid ContactId { get; set; }

        public List<Display.ResearchAreaDisplayModel> ResearchAreas { get; set; } = new List<Display.ResearchAreaDisplayModel>();

        public List<DocumentInputModel> EditionDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentInputModel> IncomingDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentDisplayModel> OutgoingDocuments { get; set; } = new List<DocumentDisplayModel>();

        public Persistence.Entities.Financier Export()
        {
            var entity = new Persistence.Entities.Financier { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Financier entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Financier entity)
        {
            entity.Priority = Priority;

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }

            entity.ResearchAreaBridges.Clear();
            entity.ResearchAreaBridges = ResearchAreas.Select(model => new Persistence.Entities.FinancierResearchAreaBridge { ProwId = entity.Id, SternId = model.Id }).ToList();
        }
    }
}
