using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class AnalysisConfigurationPageModel : AbstractConfigurationPageModel<AnalysisDisplayModel>
{
    public static string WorkPlanValidableProperty => nameof(WorkPlan);
    public static string SampleValidableProperty => nameof(Sample);
    public static string TechniqueValidableProperty => nameof(Technique);
    public static string DescriptionValidableProperty => nameof(Description);

    private System.DateTime at;
    private string description;
    private WorkPlanDisplayModel workPlan;
    private SampleOverviewModel sample;
    private TechniqueDisplayModel technique;

    public AnalysisConfigurationPageModel(AnalysisDisplayModel model, IEnumerable<TechniqueDisplayModel> availableTechniques) : base(model)
    {
        AvailableTechniques = [.. availableTechniques];

        at = System.DateTime.Now;

        if (model == null) return;

        Id = model.Id;
        at = model.At;
        description = model.Description;
        workPlan = model.WorkPlan;
        sample = model.Sample;
        technique = model.Technique;
    }

    public System.Guid Id { get; init; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public WorkPlanDisplayModel WorkPlan { get => workPlan; set => SetProperty(ref workPlan, value); }

    public SampleOverviewModel Sample { get => sample; set => SetProperty(ref sample, value); }

    public TechniqueDisplayModel Technique { get => technique; set => SetProperty(ref technique, value); }

    public ObservableCollection<TechniqueDisplayModel> AvailableTechniques { get; init; }
}
