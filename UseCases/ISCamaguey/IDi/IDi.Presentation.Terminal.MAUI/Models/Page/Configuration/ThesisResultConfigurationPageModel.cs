using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ThesisResultConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<ThesisResultDisplayModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string ProjectValidableProperty => nameof(Project);
    public static string DescriptionValidableProperty => nameof(Description);
    public static string InternalResearchersValidableProperty => nameof(InternalResearchers);
    public static string ExternalResearchersValidableProperty => nameof(ExternalResearchers);

    private string title;
    private string description;
    private System.DateTime at = System.DateTime.Now;
    private ProjectDisplayModel project;

    public ThesisResultConfigurationPageModel(ThesisResultDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        description = model.Description;
        at = model.At;
        project = model.Project;

        InternalResearchers = [.. model.InternalResearchers];
        ExternalResearchers = [.. model.ExternalResearchers];
    }

    public System.Guid Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public ProjectDisplayModel Project { get => project; set => SetProperty(ref project, value); }

    public ObservableCollection<InternalResearcherDisplayModel> InternalResearchers { get; init; }

    public ObservableCollection<ExternalResearcherDisplayModel> ExternalResearchers { get; init; }
}