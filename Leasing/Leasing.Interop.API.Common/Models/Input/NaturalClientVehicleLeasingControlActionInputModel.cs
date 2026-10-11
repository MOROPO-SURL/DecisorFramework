using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public sealed class NaturalClientVehicleLeasingControlActionInputModel : Contract.AbstractLeasingControlActionInputModel<NaturalClientVehicleLeasingControlAction>
    {
        public System.Guid LeasingId { get; set; }

        public override NaturalClientVehicleLeasingControlAction Export()
        {
            var entity = new NaturalClientVehicleLeasingControlAction { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(NaturalClientVehicleLeasingControlAction entity)
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
