namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Bridge.Display
{
    public class DriveLicenceVehicleKindBridgeDisplayModel
    {
        public Domain.Interop.API.Common.Models.Display.VehicleKindDisplayModel Stern { get; set; }

        public Persistence.Enumerations.DriveLicenceCategory Category { get; set; }

        public System.DateTime AchievedAt { get; set; }
    }
}
