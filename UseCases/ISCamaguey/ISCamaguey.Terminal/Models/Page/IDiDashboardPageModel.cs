namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public sealed class IDiDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private bool isModuleReady;
    private bool hasAnyAwardKind;
    private bool hasAnyScientificTechnicalResultKind;
    private bool hasAnyProgramKind;
    private bool hasAnyProjectCategory;
    private bool hasAnyResearcherCategory;
    private bool hasAnyTeachingCategory;
    private long callForPropousalCount;
    private long projectCount;
    private long scientificTechnicalResultIntroductionCount;
    private long publicationCount;
    private long thesisCount;
    private long awardCount;
    private long scientificTechnicalResultCount;
    private long programCount;
    private long participatingOrganizationCount;
    private long researcherCount;
    private long financierCount;

    public Microsoft.Maui.Controls.ImageSource[] Images { get; set; }

    public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }

    public bool HasAnyAwardKind { get => hasAnyAwardKind; set => SetProperty(ref hasAnyAwardKind, value); }

    public bool HasAnyScientificTechnicalResultKind { get => hasAnyScientificTechnicalResultKind; set => SetProperty(ref hasAnyScientificTechnicalResultKind, value); }

    public bool HasAnyProgramKind { get => hasAnyProgramKind; set => SetProperty(ref hasAnyProgramKind, value); }

    public bool HasAnyProjectCategory { get => hasAnyProjectCategory; set => SetProperty(ref hasAnyProjectCategory, value); }

    public bool HasAnyResearcherCategory { get => hasAnyResearcherCategory; set => SetProperty(ref hasAnyResearcherCategory, value); }

    public bool HasAnyTeachingCategory { get => hasAnyTeachingCategory; set => SetProperty(ref hasAnyTeachingCategory, value); }

    public long CallForPropousalCount { get => callForPropousalCount; set => SetProperty(ref callForPropousalCount, value); }

    public long ProjectCount { get => projectCount; set => SetProperty(ref projectCount, value); }

    public long ScientificTechnicalResultIntroductionCount { get => scientificTechnicalResultIntroductionCount; set => SetProperty(ref scientificTechnicalResultIntroductionCount, value); }

    public long PublicationCount { get => publicationCount; set => SetProperty(ref publicationCount, value); }

    public long ThesisCount { get => thesisCount; set => SetProperty(ref thesisCount, value); }

    public long AwardCount { get => awardCount; set => SetProperty(ref awardCount, value); }

    public long ScientificTechnicalResultCount { get => scientificTechnicalResultCount; set => SetProperty(ref scientificTechnicalResultCount, value); }

    public long ProgramCount { get => programCount; set => SetProperty(ref programCount, value); }

    public long ParticipatingOrganizationCount { get => participatingOrganizationCount; set => SetProperty(ref participatingOrganizationCount, value); }

    public long ResearcherCount { get => researcherCount; set => SetProperty(ref researcherCount, value); }

    public long FinancierCount { get => financierCount; set => SetProperty(ref financierCount, value); }
}