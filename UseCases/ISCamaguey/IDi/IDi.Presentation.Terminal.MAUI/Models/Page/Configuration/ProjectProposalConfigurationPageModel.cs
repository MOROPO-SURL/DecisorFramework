namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class ProjectProposalConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProjectProposalDisplayModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private string title;
    private string description;
    private int priority = 1;
    private Interop.API.Common.Models.Display.ProgramDisplayModel program;
    private Interop.API.Common.Models.Display.CallForProposalDisplayModel callForPropousal;

    public ProjectProposalConfigurationPageModel(Interop.API.Common.Models.Display.ProjectProposalDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        description = model.Description;
        priority = model.Priority;
        program = model.Program;
        callForPropousal = model.CallForPropousal;
    }

    public System.Guid Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public Interop.API.Common.Models.Display.ProgramDisplayModel Program { get => program; set => SetProperty(ref program, value); }

    public Interop.API.Common.Models.Display.CallForProposalDisplayModel CallForPropousal { get => callForPropousal; set => SetProperty(ref callForPropousal, value); }
}
