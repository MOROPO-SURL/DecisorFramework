using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public sealed class NaturalClientVehicleLeasingControlActionDisplayModel : Contract.AbstractLeasingControlActionDisplayModel<NaturalClientVehicleLeasingControlAction>
    {
        public NaturalClientVehicleLeasingDisplayModel Leasing { get; set; }

        public override void Import(NaturalClientVehicleLeasingControlAction entity)
        {
            base.Import(entity);

            if (entity.Leasing != null)
            {
                Leasing = new NaturalClientVehicleLeasingDisplayModel();

                Leasing.Import(entity.Leasing);
            }
        }
    }
}
