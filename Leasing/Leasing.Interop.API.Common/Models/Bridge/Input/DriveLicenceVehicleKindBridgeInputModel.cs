namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Bridge.Input
{
    public class DriveLicenceVehicleKindBridgeInputModel
    {
        public System.Guid SternId { get; set; }

        public Persistence.Enumerations.DriveLicenceCategory Category { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string Specification { get; set; }

        public System.DateTime AchievedAt { get; set; }
    }
}