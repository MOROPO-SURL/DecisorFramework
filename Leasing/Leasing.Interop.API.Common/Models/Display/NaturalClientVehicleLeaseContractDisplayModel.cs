namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class NaturalClientVehicleLeaseContractDisplayModel : Contract.AbstractLeaseContractDisplayModel<Persistence.Entities.NaturalClientVehicleLeaseContract>
    {
        public Domain.Interop.API.Common.Models.Display.VehicleDisplayModel Vehicle { get; set; }

        public Commercial.Interop.API.Common.Models.Display.NaturalClientDisplayModel Client { get; set; }

        public override void Import(Persistence.Entities.NaturalClientVehicleLeaseContract entity)
        {
            base.Import(entity);

            if (entity.Postulation != null)
            {
                Vehicle = new Domain.Interop.API.Common.Models.Display.VehicleDisplayModel();

                Vehicle.Import(entity.Postulation.Offer.Propousal.Vehicle);
            }

            if (entity.Client != null)
            {
                Client = new Commercial.Interop.API.Common.Models.Display.NaturalClientDisplayModel();

                Client.Import(entity.Client);
            }
        }
    }
}
