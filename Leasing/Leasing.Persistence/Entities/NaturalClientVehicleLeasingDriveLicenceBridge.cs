namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientVehicleLeasingDriveLicenceBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalClientVehicleLeasing, System.Guid, DriveLicence, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public NaturalClientVehicleLeasing Prow { get; set; }

        public System.Guid SternId { get; set; }
        public DriveLicence Stern { get; set; }
    }
}
