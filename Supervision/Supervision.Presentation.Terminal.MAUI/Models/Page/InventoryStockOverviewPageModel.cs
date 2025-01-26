using MOROPO.Framework.Decisor.Supervision.Interop.API.Common.Models;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.Page
{
    public class InventoryStockOverviewPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractListEntityPageModel<InventoryStockOverviewModel>
    {
        private InventoryStockDetailsModel presentedDetails;

        public InventoryStockDetailsModel PresentedDetails { get => presentedDetails; set => SetProperty(ref presentedDetails, value); }
    }
}
