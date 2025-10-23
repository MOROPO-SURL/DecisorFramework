using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class CallForPropousalDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.CallForPropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public FinancierDisplayModel Financier { get; set; }

        public ResearchAreaDisplayModel[] ResearchAreas { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public void Import(Persistence.Entities.CallForPropousal entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;
            At = entity.At;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;
            ResearchAreas = entity.ResearchAreaBridges.OrderBy(bridge => bridge.Stern.Priority).Select(bridge =>
            {
                var model = new ResearchAreaDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.Financier != null)
            {
                Financier = new FinancierDisplayModel();

                Financier.Import(entity.Financier);
            }
        }
    }
}
