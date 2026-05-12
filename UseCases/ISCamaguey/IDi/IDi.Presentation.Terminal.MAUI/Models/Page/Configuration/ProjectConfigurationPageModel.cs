namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class ProjectConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProjectDisplayModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string AliasValidableProperty => nameof(Alias);
    public static string CodeValidableProperty => nameof(Code);
    public static string SummaryValidableProperty => nameof(Summary);
    public static string ProblemValidableProperty => nameof(Problem);
    public static string ContextValidableProperty => nameof(Context);
    public static string BeneficiaryValidableProperty => nameof(Beneficiary);
    public static string MainObjetiveValidableProperty => nameof(MainObjetive);
    public static string CategoryValidableProperty => nameof(Category);
    public static string ChiefValidableProperty => nameof(Chief);
    public static string EndAtValidableProperty => nameof(EndAt);
    public static string DocumentValidableProperty => nameof(Document);

    private string name;
    private string alias;
    private string code;
    private string summary;
    private string problem;
    private string context;
    private string beneficiary;
    private string mainObjetive;
    private System.DateTime startAt;
    private System.DateTime endAt;
    private Interop.API.Common.Models.Display.ProjectCategoryDisplayModel category;
    private Interop.API.Common.Models.Display.InternalResearcherDisplayModel chief;
    private Interop.API.Common.Models.Display.ProgramDisplayModel program;
    private Interop.API.Common.Models.Display.ProjectProposalDisplayModel proposal;
    private Interop.API.Common.Models.Display.ProjectDisplayModel predecessor;
    private Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel document;
    private int priority = 1;

    public ProjectConfigurationPageModel(Interop.API.Common.Models.Display.ProjectDisplayModel model) : base(model)
    {
        startAt = System.DateTime.Now;
        endAt = startAt.AddYears(3);

        if (model == null) return;

        Id = model.Id;
        name = model.Name;
        alias = model.Alias;
        code = model.Code;
        category = model.Category;
        startAt = model.StartAt;
        endAt = model.EndAt;
        summary = model.Summary;
        problem = model.Problem;
        context = model.Context;
        beneficiary = model.Beneficiary;
        mainObjetive = model.MainObjetive;
        chief = model.Chief;
        program = model.Program;
        proposal = model.Proposal;
        predecessor = model.Predecessor;
        document = model.Document;

        SpecificObjectives = [.. model.SpecificObjectives];
    }

    public System.Guid Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public string Alias { get => alias; set => SetProperty(ref alias, value); }

    public string Code { get => code; set => SetProperty(ref code, value); }

    public string Summary { get => summary; set => SetProperty(ref summary, value); }

    public string Problem { get => problem; set => SetProperty(ref problem, value); }

    public string Context { get => context; set => SetProperty(ref context, value); }

    public string Beneficiary { get => beneficiary; set => SetProperty(ref beneficiary, value); }

    public string MainObjetive { get => mainObjetive; set => SetProperty(ref mainObjetive, value); }

    public System.DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

    public System.DateTime EndAt { get => endAt; set => SetProperty(ref endAt, value); }

    public Interop.API.Common.Models.Display.ProjectCategoryDisplayModel Category { get => category; set => SetProperty(ref category, value); }

    public Interop.API.Common.Models.Display.InternalResearcherDisplayModel Chief { get => chief; set => SetProperty(ref chief, value); }

    public Interop.API.Common.Models.Display.ProgramDisplayModel Program { get => program; set => SetProperty(ref program, value); }

    public Interop.API.Common.Models.Display.ProjectProposalDisplayModel Proposal { get => proposal; set => SetProperty(ref proposal, value); }

    public Interop.API.Common.Models.Display.ProjectDisplayModel Predecessor { get => predecessor; set => SetProperty(ref predecessor, value); }

    public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get => document; set => SetProperty(ref document, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel> SpecificObjectives { get; set; } = [];

    public Interop.API.Common.Models.Display.ProjectCategoryDisplayModel[] AvailableCategories { get; set; } = [];
}