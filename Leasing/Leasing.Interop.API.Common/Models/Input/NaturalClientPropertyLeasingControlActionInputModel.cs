using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public sealed class NaturalClientPropertyLeasingControlActionInputModel : Contract.AbstractLeasingControlActionInputModel<NaturalClientPropertyLeasingControlAction>
    {
        public System.Guid LeasingId { get; set; }

        public override NaturalClientPropertyLeasingControlAction Export()
        {
            var entity = new NaturalClientPropertyLeasingControlAction { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(NaturalClientPropertyLeasingControlAction entity)
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