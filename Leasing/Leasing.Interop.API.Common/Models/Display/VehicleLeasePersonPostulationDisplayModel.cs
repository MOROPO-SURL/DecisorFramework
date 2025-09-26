namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class VehicleLeasePersonPostulationDisplayModel : Contract.AbstractLeasePersonPostulationDisplayModel<Persistence.Entities.VehicleLeasePersonPostulation>
    {
        public override void Import(Persistence.Entities.VehicleLeasePersonPostulation entity)
        {
            base.Import(entity);

            OfferId = entity.OfferId;
        }
    }
}
