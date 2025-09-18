namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class NaturalClientVehicleLeasingDisplayModel : Contract.AbstractLeasingDisplayModel<Persistence.Entities.NaturalClientVehicleLeasing>
    {
        public NaturalClientVehicleLeaseContractDisplayModel Contract { get; set; }

        public string OperativeLicenceCode { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] Drivers { get; set; }

        public override void Import(Persistence.Entities.NaturalClientVehicleLeasing entity)
        {
            base.Import(entity);

            OperativeLicenceCode = entity.OperativeLicenceCode;
        }
    }
}
