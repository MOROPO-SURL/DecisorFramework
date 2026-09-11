using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class AssessmentConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<AssessmentDisplayModel>
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

    public AssessmentConfigurationPageModel(AssessmentDisplayModel model) : base(model)
    {
        at = System.DateTime.Now;

        if (model == null) return;

        Id = model.Id;
        at = model.At;
        description = model.Description;
        workPlan = model.WorkPlan;
        sample = model.Sample;
        author = model.Author;
        document = model.Document;
    }

    public System.Guid Id { get; init; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public WorkPlanDisplayModel WorkPlan { get => workPlan; set => SetProperty(ref workPlan, value); }

    public SampleOverviewModel Sample { get => sample; set => SetProperty(ref sample, value); }

    public EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

    public DocumentDisplayModel Document { get => document; set => SetProperty(ref document, value); }

    public ObservableCollection<AnalysisDisplayModel> Analyses { get; set; } = [];
}