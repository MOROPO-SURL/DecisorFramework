namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class NaturalClientPropertyLeasingCollectDisplayModel : Financial.Interop.API.Common.Models.Display.Contract.AbstractCollectDisplayModel<Persistence.Entities.NaturalClientPropertyLeasingCollect>
    {
        public NaturalClientPropertyLeasingDisplayModel Leasing { get; set; }

        public override void Import(Persistence.Entities.NaturalClientPropertyLeasingCollect entity)
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
