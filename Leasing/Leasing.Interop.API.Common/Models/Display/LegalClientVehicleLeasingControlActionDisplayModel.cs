using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public sealed class LegalClientVehicleLeasingControlActionDisplayModel : Contract.AbstractLeasingControlActionDisplayModel<LegalClientVehicleLeasingControlAction>
    {
        public LegalClientVehicleLeasingDisplayModel Leasing { get; set; }

        public override void Import(LegalClientVehicleLeasingControlAction entity)
        {
            base.Import(entity);

            if (entity.Leasing != null)
            {
                Leasing = new LegalClientVehicleLeasingDisplayModel();

                Leasing.Import(entity.Leasing);
            }
        }
    }
}
