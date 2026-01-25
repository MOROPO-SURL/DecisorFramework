namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class LegalClientVehicleLeasingDisplayModel : Contract.AbstractLeasingDisplayModel<Persistence.Entities.LegalClientVehicleLeasing>
    {
        public LegalClientVehicleLeaseContractDisplayModel Contract { get; set; }

        public string OperativeLicenceCode { get; set; }

        public DriveLicenceDisplayModel[] DriverLicences { get; set; }

        public override void Import(Persistence.Entities.LegalClientVehicleLeasing entity)
        {
            base.Import(entity);

            OperativeLicenceCode = entity.OperativeLicenceCode;

            if (entity.Contract != null)
            {
                Contract = new LegalClientVehicleLeaseContractDisplayModel();

                Contract.Import(entity.Contract);
            }
        }
    }
}
