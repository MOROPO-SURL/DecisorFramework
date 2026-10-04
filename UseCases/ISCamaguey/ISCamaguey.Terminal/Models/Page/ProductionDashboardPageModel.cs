namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public sealed class ProductionDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private bool isModuleReady;
    private bool hasAnyUnitMeasurement;
    private bool hasAnyElaboration;
    private long orderCount;
    private long productionCount;
    private long qualityCheckCount;
    private long elaborationCount;
    private long productCount;
    private long familyCount;
    private long unitMeasurementCount;

    public Microsoft.Maui.Controls.ImageSource[] Images { get; set; }

    public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }

    public bool HasAnyUnitMeasurement { get => hasAnyUnitMeasurement; set => SetProperty(ref hasAnyUnitMeasurement, value); }

    public bool HasAnyElaboration { get => hasAnyElaboration; set => SetProperty(ref hasAnyElaboration, value); }

    public long OrderCount { get => orderCount; set => SetProperty(ref orderCount, value); }

    public long ProductionCount { get => productionCount; set => SetProperty(ref productionCount, value); }

    public long QualityCheckCount { get => qualityCheckCount; set => SetProperty(ref qualityCheckCount, value); }

    public long ElaborationCount { get => elaborationCount; set => SetProperty(ref elaborationCount, value); }

    public long ProductCount { get => productCount; set => SetProperty(ref productCount, value); }

    public long FamilyCount { get => familyCount; set => SetProperty(ref familyCount, value); }

    public long UnitMeasurementCount { get => unitMeasurementCount; set => SetProperty(ref unitMeasurementCount, value); }
}