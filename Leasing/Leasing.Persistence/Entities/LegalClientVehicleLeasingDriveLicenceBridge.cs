namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientVehicleLeasingDriveLicenceBridge : Guama.Core.Persistence.Entities.Contract.IBridge<LegalClientVehicleLeasing, System.Guid, DriveLicence, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public LegalClientVehicleLeasing Prow { get; set; }

        public System.Guid SternId { get; set; }
        public DriveLicence Stern { get; set; }
    }
}
