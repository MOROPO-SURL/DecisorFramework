namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Bridge.Display
{
    public class DriveLicenceVehicleKindBridgeDisplayModel
    {
        public Domain.Interop.API.Common.Models.Display.VehicleKindDisplayModel Stern { get; set; }

        public Persistence.Enumerations.DriveLicenceCategory Category { get; set; }

        public string Specification { get; set; }

        public System.DateTime AchievedAt { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DriveLicenceVehicleKindBridgeDisplayModel)) return false;

            var concreteObject = obj as DriveLicenceVehicleKindBridgeDisplayModel;

            return 
                Stern.Id == concreteObject.Stern.Id &&
                Category == concreteObject.Category;
        }
    }
}
