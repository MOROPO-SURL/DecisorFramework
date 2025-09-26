namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class LegalClientPropertyLeasingCollectDisplayModel : Financial.Interop.API.Common.Models.Display.Contract.AbstractCollectDisplayModel<Persistence.Entities.LegalClientPropertyLeasingCollect>
    {
        public LegalClientPropertyLeasingDisplayModel Leasing { get; set; }

        public override void Import(Persistence.Entities.LegalClientPropertyLeasingCollect entity)
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
