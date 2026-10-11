using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public sealed class NaturalClientPropertyLeasingControlActionDisplayModel : Contract.AbstractLeasingControlActionDisplayModel<NaturalClientPropertyLeasingControlAction>
    {
        public NaturalClientPropertyLeasingDisplayModel Leasing { get; set; }

        public override void Import(NaturalClientPropertyLeasingControlAction entity)
        {
            base.Import(entity);

            if (entity.Leasing != null)
            {
                Leasing = new NaturalClientPropertyLeasingDisplayModel();

                Leasing.Import(entity.Leasing);
            }
        }
    }
}
