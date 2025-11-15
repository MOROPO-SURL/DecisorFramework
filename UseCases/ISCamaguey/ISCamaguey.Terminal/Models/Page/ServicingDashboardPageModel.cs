namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page
{
    public class ServicingDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private long orderCount;
        private long trainingServiceCount;
        private long sapleAnalisysServiceCount;
        private long groundIntegralStudyServiceCount;
        private long sampleKindCount;
        private bool isCollectBalanceMontlyChartMock;
        private bool isOrderReceptionBalanceMontlyChartMock;
        private bool isOrderDistributionChartMock;
        private bool isMostClientOrderBalanceChartMock;
        private View.ChartViewModel collectBalanceMontlyChart;
        private View.ChartViewModel orderReceptionBalanceMontlyChart;
        private View.ChartViewModel mostClientOrderBalanceChart;

        public View.ChartViewModel CollectBalanceMontlyChart { get => collectBalanceMontlyChart; set => SetProperty(ref collectBalanceMontlyChart, value); }

        public View.ChartViewModel OrderReceptionBalanceMontlyChart { get => orderReceptionBalanceMontlyChart; set => SetProperty(ref orderReceptionBalanceMontlyChart, value); }

        public View.ChartViewModel OrderDistributionChart { get; set; }

        public View.ChartViewModel MostClientOrderBalanceChart { get => mostClientOrderBalanceChart; set => SetProperty(ref mostClientOrderBalanceChart, value); }

        public long OrderCount { get => orderCount; set => SetProperty(ref orderCount, value); }

        public long TrainingServiceCount { get => trainingServiceCount; set => SetProperty(ref trainingServiceCount, value); }

        public long SampleAnalysisServiceCount { get => sapleAnalisysServiceCount; set => SetProperty(ref sapleAnalisysServiceCount, value); }

        public long GroundIntegralStudyServiceCount { get => groundIntegralStudyServiceCount; set => SetProperty(ref groundIntegralStudyServiceCount, value); }

        public long SampleKindCount { get => sampleKindCount; set => SetProperty(ref sampleKindCount, value); }

        public bool IsCollectBalanceMontlyChartMock { get => isCollectBalanceMontlyChartMock; set => SetProperty(ref isCollectBalanceMontlyChartMock, value); }

        public bool IsOrderReceptionBalanceMontlyChartMock { get => isOrderReceptionBalanceMontlyChartMock; set => SetProperty(ref isOrderReceptionBalanceMontlyChartMock, value); }

        public bool IsOrderDistributionChartMock { get => isOrderDistributionChartMock; set => SetProperty(ref isOrderDistributionChartMock, value); }

        public bool IsMostClientOrderBalanceChartMock { get => isMostClientOrderBalanceChartMock; set => SetProperty(ref isMostClientOrderBalanceChartMock, value); }
    }
}
