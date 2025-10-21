using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class FinancierDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Financier, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get; set; }

        public ResearchAreaDisplayModel[] ResearchAreas { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public void Import(Persistence.Entities.Financier entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            ResearchAreas = entity.ResearchAreaBridges.OrderBy(bridge => bridge.Stern.Priority).Select(bridge =>
            {
                var model = new ResearchAreaDisplayModel();

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
