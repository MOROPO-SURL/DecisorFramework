namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.Page
{
    public class InventoryDashboardPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private long productDefinitionCount;
        private long warehouseCount;
        private long categoryCount;

        public View.ChartViewModel ReceptionsChart {  get; set; }

        public View.ChartViewModel DeparturesChart { get; set; }

        public View.ChartViewModel WarehoursesChart { get; set; }

        public View.ChartViewModel RootCategoriesChart { get; set; }

        public View.ChartViewModel ProductsChart { get; set; }

        public long ProductDefinitionCount { get => productDefinitionCount; set => SetProperty(ref productDefinitionCount, value); }

        public long WarehouseCount { get => warehouseCount; set => SetProperty(ref warehouseCount, value); }

        public long CategoryCount { get => categoryCount; set => SetProperty(ref categoryCount, value); }
    }
}
