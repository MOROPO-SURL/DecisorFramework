using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class AssessmentConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<View.AssessmentDetailViewModel>
{
    public static string WorkPlanValidableProperty => nameof(WorkPlan);
    public static string SampleValidableProperty => nameof(Sample);
    public static string AuthorValidableProperty => nameof(Author);
    public static string DescriptionValidableProperty => nameof(Description);
    public static string AnalysesValidableProperty => nameof(Analyses);
    public static string DocumentValidableProperty => nameof(Document);

    private System.DateTime at;
    private string description;
    private WorkPlanDisplayModel workPlan;
    private SampleOverviewModel sample;
    private EmployeeDisplayModel author;
    private DocumentDisplayModel document;

    public AssessmentConfigurationPageModel(View.AssessmentDetailViewModel model) : base(model)
    {
        at = System.DateTime.Now;

        if (model == null) return;

        Id = model.Target.Id;
        at = model.Target.At;
        description = model.Target.Description;
        workPlan = model.Target.WorkPlan;
        sample = model.Target.Sample;
        author = model.Target.Author;
        document = model.Target.Document;

        Analyses = [.. model.Analises];
    }

    public System.Guid Id { get; init; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public WorkPlanDisplayModel WorkPlan { get => workPlan; set => SetProperty(ref workPlan, value); }

    public SampleOverviewModel Sample { get => sample; set => SetProperty(ref sample, value); }

    public EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

    public DocumentDisplayModel Document { get => document; set => SetProperty(ref document, value); }

    public ObservableCollection<View.AnalysisDetailViewModel> Analyses { get; init; } = [];
}