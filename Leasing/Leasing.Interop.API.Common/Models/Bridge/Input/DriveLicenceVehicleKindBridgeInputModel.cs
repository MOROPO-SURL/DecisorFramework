namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Bridge.Input
{
    public class DriveLicenceVehicleKindBridgeInputModel
    {
        public System.Guid SternId { get; set; }

        public Persistence.Enumerations.DriveLicenceCategory Category { get; set; }

        public System.DateTime AchievedAt { get; set; }
    }
}