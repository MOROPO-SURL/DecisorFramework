namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.View
{
	public class BatchSpecificationViewModel
	{
        public string ExternalReference { get; set; }

        public decimal Amount { get; set; }

        public Inventory.Interop.API.Common.Models.Display.WarehouseDisplayModel Warehouse { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get; set; }
    }
}

