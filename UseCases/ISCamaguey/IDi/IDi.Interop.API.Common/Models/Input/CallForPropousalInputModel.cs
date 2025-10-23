using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class CallForPropousalInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.CallForPropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public System.Guid FinancierId { get; set; }

        public List<Display.ResearchAreaDisplayModel> ResearchAreas { get; set; } = new List<Display.ResearchAreaDisplayModel>();

        public List<DocumentInputModel> EditionDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentInputModel> IncomingDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentDisplayModel> OutgoingDocuments { get; set; } = new List<DocumentDisplayModel>();

        public Persistence.Entities.CallForPropousal Export()
        {
            var entity = new Persistence.Entities.CallForPropousal { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.CallForPropousal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.CallForPropousal entity)
        {
            entity.Title = Title;
            entity.Description = Description;
            entity.StartAt = StartAt;
            entity.EndAt = EndAt;

            if (entity.FinancierId != FinancierId)
            {
                entity.Financier = null;
                entity.FinancierId = FinancierId;
            }

            entity.ResearchAreaBridges.Clear();
            entity.ResearchAreaBridges = ResearchAreas.Select(model => new Persistence.Entities.CallForPropousalResearchAreaBridge { ProwId = entity.Id, SternId = model.Id }).ToList();
        }
    }
}
