using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public sealed class LegalClientPropertyLeasingControlActionDisplayModel : Contract.AbstractLeasingControlActionDisplayModel<LegalClientPropertyLeasingControlAction>
    {
        public LegalClientPropertyLeasingDisplayModel Leasing { get; set; }

        public override void Import(LegalClientPropertyLeasingControlAction entity)
        {
            base.Import(entity);

            if (entity.Leasing != null)
            {
                Leasing = new LegalClientPropertyLeasingDisplayModel();

                Leasing.Import(entity.Leasing);
            }
        }
    }
}
