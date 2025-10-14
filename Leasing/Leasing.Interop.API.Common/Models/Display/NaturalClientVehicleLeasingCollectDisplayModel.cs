namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class NaturalClientVehicleLeasingCollectDisplayModel : Financial.Interop.API.Common.Models.Display.Contract.AbstractCollectDisplayModel<Persistence.Entities.NaturalClientVehicleLeasingCollect>
    {
        public NaturalClientVehicleLeasingDisplayModel Leasing { get; set; }

        public override void Import(Persistence.Entities.NaturalClientVehicleLeasingCollect entity)
        {
            base.Import(entity);

            if (entity.Leasing != null)
            {
                Leasing = new NaturalClientVehicleLeasingDisplayModel();

                Leasing.Import(entity.Leasing);
            }
        }
    }
}
