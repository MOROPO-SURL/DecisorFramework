namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class DriveLicenceVehicleKindBridge : Guama.Core.Persistence.Entities.Contract.IBridge<DriveLicence, System.Guid, Domain.Persistence.Entities.VehicleKind, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public DriveLicence Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.VehicleKind Stern { get; set; }

        public Enumerations.DriveLicenceCategory Category { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string Specification { get; set; }

        public System.DateTime AchievedAt { get; set; }
    }
}
