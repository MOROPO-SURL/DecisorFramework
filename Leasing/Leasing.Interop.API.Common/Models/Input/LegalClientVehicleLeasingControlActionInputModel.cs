using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public sealed class LegalClientVehicleLeasingControlActionInputModel : Contract.AbstractLeasingControlActionInputModel<LegalClientVehicleLeasingControlAction>
    {
        public System.Guid LeasingId { get; set; }

        public override LegalClientVehicleLeasingControlAction Export()
        {
            var entity = new LegalClientVehicleLeasingControlAction { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(LegalClientVehicleLeasingControlAction entity)
        {
            base.Mergue(entity);

            if (entity.LeasingId != LeasingId)
            {
                entity.Leasing = null;
                entity.LeasingId = LeasingId;
            }
        }
    }
}