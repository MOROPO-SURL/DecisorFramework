using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class AnalysisConfigurationPageModel : AbstractConfigurationPageModel<AnalysisDisplayModel>
{
    public static string WorkPlanValidableProperty => nameof(WorkPlan);
    public static string SampleValidableProperty => nameof(Sample);
    public static string TechniqueValidableProperty => nameof(Technique);
    public static string AuthorValidableProperty => nameof(Author);
    public static string DescriptionValidableProperty => nameof(Description);

    private System.DateTime at;
    private System.TimeSpan time;
    private string description;
    private WorkPlanDisplayModel workPlan;
    private SampleOverviewModel sample;
    private TechniqueDisplayModel technique;
    private EmployeeDisplayModel author;

    public AnalysisConfigurationPageModel(AnalysisDisplayModel model, IEnumerable<TechniqueDisplayModel> availableTechniques) : base(model)
    {
        AvailableTechniques = [.. availableTechniques];

        at = System.DateTime.Today;
        time = System.DateTime.Now.TimeOfDay;

        if (model == null) return;

        Id = model.Id;
        at = model.At;
        time = model.At.TimeOfDay;
        description = model.Description;
        workPlan = model.WorkPlan;
        sample = model.Sample;
        technique = AvailableTechniques.SingleOrDefault(item => item.Id == model.Technique.Id);
        author = model.Author;
    }

    public System.Guid Id { get; init; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public System.TimeSpan Time { get => time; set => SetProperty(ref time, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public WorkPlanDisplayModel WorkPlan { get => workPlan; set => SetProperty(ref workPlan, value); }

    public SampleOverviewModel Sample { get => sample; set => SetProperty(ref sample, value); }

    public TechniqueDisplayModel Technique { get => technique; set => SetProperty(ref technique, value); }

    public EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

    public ObservableCollection<TechniqueDisplayModel> AvailableTechniques { get; init; }
}