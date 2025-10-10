namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class LegalClientVehicleLeasingCollectDisplayModel : Financial.Interop.API.Common.Models.Display.Contract.AbstractCollectDisplayModel<Persistence.Entities.LegalClientVehicleLeasingCollect>
    {
        public LegalClientVehicleLeasingDisplayModel Leasing { get; set; }

        public override void Import(Persistence.Entities.LegalClientVehicleLeasingCollect entity)
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
