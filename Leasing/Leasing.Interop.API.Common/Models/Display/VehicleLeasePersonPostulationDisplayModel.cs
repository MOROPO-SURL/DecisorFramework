using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class VehicleLeasePersonPostulationDisplayModel : Contract.AbstractLeasePersonPostulationDisplayModel<Persistence.Entities.VehicleLeasePersonPostulation>
    {
        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public override void Import(Persistence.Entities.VehicleLeasePersonPostulation entity)
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
