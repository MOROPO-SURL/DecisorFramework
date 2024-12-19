namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Bridge
{
    public class ProductContactBridgeModel
    {
        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public string Description { get; set; }

        public int Evaluation { get; set; }
    }
}
