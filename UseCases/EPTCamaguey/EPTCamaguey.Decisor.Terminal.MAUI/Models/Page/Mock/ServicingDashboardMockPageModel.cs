using MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.View;

namespace MOROPO.EPTCamaguey.Decisor.Terminal.MAUI.Models.Page.Mock
{
    public class ServicingDashboardMockPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private long tenderCount;
        private long leaseCount;
        private long clientCount;

        public ChartViewModel LeasyTypeAreaChart { get; set; }

        public ChartViewModel PaymentProgressChart { get; set; }

        public ChartViewModel LatePaymentByClientHeatChart { get; set; }

        public long TenderCount { get => tenderCount; set => SetProperty(ref tenderCount, value); }

        public long LeaseCount { get => leaseCount; set => SetProperty(ref leaseCount, value); }

        public long ClientCount { get => clientCount; set => SetProperty(ref clientCount, value); }
    }
}
