namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public sealed class LabDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private bool isModuleReady;
    private bool hasAnySampleKind;
    private bool hasAnyUnitMeasurement;
    private bool hasAnyTechnique;
    private bool hasAnyWorkingGroup;
    private long sampleCount;
    private long analysisCount;
    private long assentmentCount;
    private long qualityCheckCount;
    private long workGroupCount;
    private long workPlanCount;
    private long techniqueCount;
    private long unitMeasurementCount;
    private long sampleKindCount;

    public Microsoft.Maui.Controls.ImageSource[] Images { get; set; }

    public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }

    public bool HasAnySampleKind { get => hasAnySampleKind; set => SetProperty(ref hasAnySampleKind, value); }

    public bool HasAnyUnitMeasurement { get => hasAnyUnitMeasurement; set => SetProperty(ref hasAnyUnitMeasurement, value); }

    public bool HasAnyTechnique { get => hasAnyTechnique; set => SetProperty(ref hasAnyTechnique, value); }

    public bool HasAnyWorkingGroup { get => hasAnyWorkingGroup; set => SetProperty(ref hasAnyWorkingGroup, value); }

    public long SampleCount { get => sampleCount; set => SetProperty(ref sampleCount, value); }

    public long AnalysisCount { get => analysisCount; set => SetProperty(ref analysisCount, value); }

    public long AssentmentCount { get => assentmentCount; set => SetProperty(ref assentmentCount, value); }

    public long QualityCheckCount { get => qualityCheckCount; set => SetProperty(ref qualityCheckCount, value); }

    public long WorkGroupCount { get => workGroupCount; set => SetProperty(ref workGroupCount, value); }

    public long WorkPlanCount { get => workPlanCount; set => SetProperty(ref workPlanCount, value); }

    public long TechniqueCount { get => techniqueCount; set => SetProperty(ref techniqueCount, value); }

    public long UnitMeasurementCount { get => unitMeasurementCount; set => SetProperty(ref unitMeasurementCount, value); }

    public long SampleKindCount { get => sampleKindCount; set => SetProperty(ref sampleKindCount, value); }
}
