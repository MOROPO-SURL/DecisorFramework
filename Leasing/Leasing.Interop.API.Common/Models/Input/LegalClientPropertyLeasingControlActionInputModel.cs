using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public sealed class LegalClientPropertyLeasingControlActionInputModel : Contract.AbstractLeasingControlActionInputModel<LegalClientPropertyLeasingControlAction>
    {
        public System.Guid LeasingId { get; set; }

        public override LegalClientPropertyLeasingControlAction Export()
        {
            var entity = new LegalClientPropertyLeasingControlAction { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(LegalClientPropertyLeasingControlAction entity)
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