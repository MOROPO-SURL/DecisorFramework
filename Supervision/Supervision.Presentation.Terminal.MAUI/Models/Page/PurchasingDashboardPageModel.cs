namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.Page
{
    public class PurchasingDashboardPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private long purchasePlanCount;
        private long purchaseCount;
        private long providerCount;
        private long purchaseZoneCount;

        public View.ChartViewModel PurchaseLastMonthsCountAreaChart { get; set; }

        public View.ChartViewModel PurchaseZonePurchasesDoughnutChart { get; set; }

        public View.ChartViewModel ProviderPurchasingAmountHeatChart { get; set; }

        public long PurchasePlanCount { get => purchasePlanCount; set => SetProperty(ref purchasePlanCount, value); }

        public long PurchaseCount { get => purchaseCount; set => SetProperty(ref purchaseCount, value); }

        public long ProviderCount { get => providerCount; set => SetProperty(ref providerCount, value); }

        public long PurchaseZoneCount { get => purchaseZoneCount; set => SetProperty(ref purchaseZoneCount, value); }
    }
}
