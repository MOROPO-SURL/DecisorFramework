namespace MOROPO.Framework.Decisor.Sales.Interop.API.Common.Models
{
    public class StockOverviewModel
    {
        public System.Guid Id { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Totalization { get; set; }
    }
}
