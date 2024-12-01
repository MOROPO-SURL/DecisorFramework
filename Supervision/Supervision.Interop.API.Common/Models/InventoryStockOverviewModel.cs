namespace MOROPO.Framework.Decisor.Supervision.Interop.API.Common.Models
{
    public class InventoryStockOverviewModel
    {
        public System.Guid Id { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Totalization { get; set; }
    }
}
