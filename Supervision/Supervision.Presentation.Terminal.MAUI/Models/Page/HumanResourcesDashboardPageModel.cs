namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.Page;

public class HumanResourcesDashboardPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
{
    private System.Action staffChangedCallbackAction;

    private HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel staff;
    private bool isStaffCompletitionGlobalPieChartMock = true;
    private View.ChartViewModel staffCompletitionGlobalPieChart = new();
    private bool isStaffCompletitionByWorkPositionKindCartesianChartMock = true;
    private View.ChartViewModel staffCompletitionByWorkPositionKindCartesianChart = new();
    private bool isStaffCompletitionPathMontlyCartesianChartMock = true;
    private View.ChartViewModel staffCompletitionPathMontlyCartesianChart = new();
    private bool isStaffCompositionByAgePieChartMock = true;
    private View.ChartViewModel staffCompositionByAgePieChart = new();
    private bool isStaffCompositionBySexPieChartMock = true;
    private View.ChartViewModel staffCompositionBySexPieChart = new();
    private bool isStaffCompositionBySkinKindPieChartMock = true;
    private View.ChartViewModel staffCompositionBySkinKindPieChart = new();

    protected override void DisposeUnmanagedResources()
    {
        base.DisposeUnmanagedResources();

        staffChangedCallbackAction = null;
    }

    public void Bind(System.Action staffChangedCallbackAction)
    {
        this.staffChangedCallbackAction = staffChangedCallbackAction;
    }

    public HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel Staff { get => staff; set => SetProperty(ref staff, value, staffChangedCallbackAction); }

    public bool IsStaffCompletitionGlobalPieChartMock { get => isStaffCompletitionGlobalPieChartMock; set => SetProperty(ref isStaffCompletitionGlobalPieChartMock, value); }
    public View.ChartViewModel StaffCompletitionGlobalPieChart { get => staffCompletitionGlobalPieChart; set => SetProperty(ref staffCompletitionGlobalPieChart, value); }

    public System.Collections.ObjectModel.ObservableCollection<HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel> AvailableStaffs { get; set; }

    public bool IsStaffCompletitionByWorkPositionKindCartesianChartMock { get => isStaffCompletitionByWorkPositionKindCartesianChartMock; set => SetProperty(ref isStaffCompletitionByWorkPositionKindCartesianChartMock, value); }
    public View.ChartViewModel StaffCompletitionByWorkPositionKindCartesianChart { get => staffCompletitionByWorkPositionKindCartesianChart; set => SetProperty(ref staffCompletitionByWorkPositionKindCartesianChart, value); }

    public bool IsStaffCompletitionPathMontlyCartesianChartMock { get => isStaffCompletitionPathMontlyCartesianChartMock; set => SetProperty(ref isStaffCompletitionPathMontlyCartesianChartMock, value); }
    public View.ChartViewModel StaffCompletitionPathMontlyCartesianChart { get => staffCompletitionPathMontlyCartesianChart; set => SetProperty(ref staffCompletitionPathMontlyCartesianChart, value); }

    public bool IsStaffCompositionByAgePieChartMock { get => isStaffCompositionByAgePieChartMock; set => SetProperty(ref isStaffCompositionByAgePieChartMock, value); }
    public View.ChartViewModel StaffCompositionByAgePieChart { get => staffCompositionByAgePieChart; set => SetProperty(ref staffCompositionByAgePieChart, value); }

    public bool IsStaffCompositionBySexPieChartMock { get => isStaffCompositionBySexPieChartMock; set => SetProperty(ref isStaffCompositionBySexPieChartMock, value); }
    public View.ChartViewModel StaffCompositionBySexPieChart { get => staffCompositionBySexPieChart; set => SetProperty(ref staffCompositionBySexPieChart, value); }

    public bool IsStaffCompositionBySkinKindPieChartMock { get => isStaffCompositionBySkinKindPieChartMock; set => SetProperty(ref isStaffCompositionBySkinKindPieChartMock, value); }
    public View.ChartViewModel StaffCompositionBySkinKindPieChart { get => staffCompositionBySkinKindPieChart; set => SetProperty(ref staffCompositionBySkinKindPieChart, value); }
}
