namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page
{
    public class ServicingDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private bool isModuleReady;
        private bool hasAnySampleKind;
        private long trainingServiceCount;
        private long sapleAnalisysServiceCount;
        private long groundIntegralStudyServiceCount;
        private long sampleKindCount;
        private long serviceOrderCount;
        private long serviceExecutionCount;
        private long clientCount;
        private long contractCount;
        //private bool isCollectBalanceMontlyChartMock;
        //private bool isOrderReceptionBalanceMontlyChartMock;
        //private bool isOrderDistributionChartMock;
        //private bool isMostClientOrderBalanceChartMock;
        //private View.ChartViewModel collectBalanceMontlyChart;
        //private View.ChartViewModel orderReceptionBalanceMontlyChart;
        //private View.ChartViewModel mostClientOrderBalanceChart;

        public Microsoft.Maui.Controls.ImageSource[] Images { get; set; }

        public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }

        public bool HasAnySampleKind { get => hasAnySampleKind; set => SetProperty(ref hasAnySampleKind, value); }

        //public View.ChartViewModel CollectBalanceMontlyChart { get => collectBalanceMontlyChart; set => SetProperty(ref collectBalanceMontlyChart, value); }

        //public View.ChartViewModel OrderReceptionBalanceMontlyChart { get => orderReceptionBalanceMontlyChart; set => SetProperty(ref orderReceptionBalanceMontlyChart, value); }

        //public View.ChartViewModel OrderDistributionChart { get; set; }

        //public View.ChartViewModel MostClientOrderBalanceChart { get => mostClientOrderBalanceChart; set => SetProperty(ref mostClientOrderBalanceChart, value); }

        public long TrainingServiceCount { get => trainingServiceCount; set => SetProperty(ref trainingServiceCount, value); }

        public long SampleAnalysisServiceCount { get => sapleAnalisysServiceCount; set => SetProperty(ref sapleAnalisysServiceCount, value); }

        public long GroundIntegralStudyServiceCount { get => groundIntegralStudyServiceCount; set => SetProperty(ref groundIntegralStudyServiceCount, value); }

        public long SampleKindCount { get => sampleKindCount; set => SetProperty(ref sampleKindCount, value); }

        public long ServiceOrderCount { get => serviceOrderCount; set => SetProperty(ref serviceOrderCount, value); }

        public long ServiceExecutionCount { get => serviceExecutionCount; set => SetProperty(ref serviceExecutionCount, value); }

        public long ClientCount { get => clientCount; set => SetProperty(ref clientCount, value); }

        public long ContractCount { get => contractCount; set => SetProperty(ref contractCount, value); }

        //public bool IsCollectBalanceMontlyChartMock { get => isCollectBalanceMontlyChartMock; set => SetProperty(ref isCollectBalanceMontlyChartMock, value); }

        //public bool IsOrderReceptionBalanceMontlyChartMock { get => isOrderReceptionBalanceMontlyChartMock; set => SetProperty(ref isOrderReceptionBalanceMontlyChartMock, value); }

        //public bool IsOrderDistributionChartMock { get => isOrderDistributionChartMock; set => SetProperty(ref isOrderDistributionChartMock, value); }

        //public bool IsMostClientOrderBalanceChartMock { get => isMostClientOrderBalanceChartMock; set => SetProperty(ref isMostClientOrderBalanceChartMock, value); }
    }
}
