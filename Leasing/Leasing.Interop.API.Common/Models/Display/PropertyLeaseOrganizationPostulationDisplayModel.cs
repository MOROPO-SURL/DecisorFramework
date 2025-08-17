using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class PropertyLeaseOrganizationPostulationDisplayModel : Contract.AbstractLeaseOrganizationPostulationDisplayModel<Persistence.Entities.PropertyLeaseOrganizationPostulation>
    {
        public PropertySpaceLeasePropousalDisplayModel[] Spaces { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public override void Import(Persistence.Entities.PropertyLeaseOrganizationPostulation entity)
        {
            base.Import(entity);

            OfferId = entity.OfferId;

            Documents = entity.DocumentBridges.Select(bridge =>
            {
                var model = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
        }
    }
}
