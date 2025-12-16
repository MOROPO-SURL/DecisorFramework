namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge
{
    public class CommonElaborationProductBridgeModel
    {
        [Newtonsoft.Json.JsonIgnore]
        public System.Guid Key { get; set; } = System.Guid.NewGuid();

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get; set; }

        public decimal Amount { get; set; }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }
    }
}