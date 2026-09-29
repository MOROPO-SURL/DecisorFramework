using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ThesisResultConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<ThesisResultDisplayModel>
{
    public static Persistence.Enumerations.ThesisKind[] AVAILABLE_THESIS_KINDS = [ Persistence.Enumerations.ThesisKind.Bachelored, Persistence.Enumerations.ThesisKind.Master, Persistence.Enumerations.ThesisKind.Doctorate ];

    public static string TitleValidableProperty => nameof(Title);
    public static string DocumentValidableProperty => nameof(Document);
    public static string ThesisKindValidableProperty => nameof(ThesisKind);
    public static string InternalResearchersValidableProperty => nameof(InternalResearchers);
    public static string ExternalResearchersValidableProperty => nameof(ExternalResearchers);

    private string title;
    private Persistence.Enumerations.ThesisKind thesisKind;
    private string description;
    private System.DateTime at = System.DateTime.Now;
    private ProjectDisplayModel project;
    private DocumentDisplayModel document;

    public ThesisResultConfigurationPageModel(ThesisResultDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        thesisKind = model.ThesisKind;
        description = model.Description;
        at = model.At;
        project = model.Project;
        document = model.Document;

        InternalResearchers = [.. model.InternalResearchers];
        ExternalResearchers = [.. model.ExternalResearchers];
    }

    public System.Guid Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public Persistence.Enumerations.ThesisKind ThesisKind { get => thesisKind; set => SetProperty(ref thesisKind, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public DocumentDisplayModel Document { get => document; set => SetProperty(ref document, value); }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public ProjectDisplayModel Project { get => project; set => SetProperty(ref project, value); }

    public ObservableCollection<InternalResearcherDisplayModel> InternalResearchers { get; init; } = [];

    public ObservableCollection<ExternalResearcherDisplayModel> ExternalResearchers { get; init; } = [];
}