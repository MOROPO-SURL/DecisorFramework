namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public class QualityDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private long certificationCount;
    private long cubanStandardCount;
    private long isoStandardCount;
    private long labRevisionCount;
    private long productionRevisionCount;
    private bool isLabRevisionMontlyChartMock;
    private bool isProductionRevisionMontlyChartMock;

    public Microsoft.Maui.Controls.ImageSource[] Images { get; set; }

    public View.ChartViewModel LabRevisionMontlyChart { get; set; }

    public View.ChartViewModel ProductionRevisionMontlyChart { get; set; }

    public long CertificationCount { get => certificationCount; set => SetProperty(ref certificationCount, value); }

    public long CubanStandardCount { get => cubanStandardCount; set => SetProperty(ref cubanStandardCount, value); }

    public long IsoStandardCount { get => isoStandardCount; set => SetProperty(ref isoStandardCount, value); }

    public long LabRevisionCount { get => labRevisionCount; set => SetProperty(ref labRevisionCount, value); }

    public long ProductionRevisionCount { get => productionRevisionCount; set => SetProperty(ref productionRevisionCount, value); }

    public bool IsLabRevisionMontlyChartMock { get => isLabRevisionMontlyChartMock; set => SetProperty(ref isLabRevisionMontlyChartMock, value); }

    public bool IsProductionRevisionMontlyChartMock { get => isProductionRevisionMontlyChartMock; set => SetProperty(ref isProductionRevisionMontlyChartMock, value); }
}