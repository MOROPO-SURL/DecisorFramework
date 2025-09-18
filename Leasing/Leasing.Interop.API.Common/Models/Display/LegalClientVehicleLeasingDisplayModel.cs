namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class LegalClientVehicleLeasingDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.LegalClientVehicleLeasing, System.Guid>
    {
        public System.Guid Id { get; set; }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public LegalClientVehicleLeaseContractDisplayModel Contract { get; set; }

        public string OperativeLicenceCode { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] Drivers { get; set; }

        public void Import(Persistence.Entities.LegalClientVehicleLeasing entity)
        {
            Id = entity.Id;
            OperativeLicenceCode = entity.OperativeLicenceCode;

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }
        }
    }
}
