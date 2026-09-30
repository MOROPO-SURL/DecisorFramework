using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Context.Contract;

public interface IIDiDbContext : Domain.Persistence.ORM.EF.Context.Contract.IDomainDbContext, Framework.Decisor.Financial.Persistence.ORM.EF.Context.Contract.IFinancialDbContext
{
    public DbSet<Entities.AwardKind> AwardKinds { get; set; }
    public DbSet<Entities.AwardResult> AwardResults { get; set; }
    public DbSet<Entities.Extension> Extensions { get; set; }
    public DbSet<Entities.ExternalResearcher> ExternalResearchers { get; set; }
    public DbSet<Entities.Financier> Financiers { get; set; }
    public DbSet<Entities.FinancierKnowledgeAreaBridge> FinancierKnowledgeAreaBridges { get; set; }
    public DbSet<Entities.FinancierDocumentBridge> FinancierDocumentBridges { get; set; }
    public DbSet<Entities.InternalResearcher> InternalResearchers { get; set; }
    public DbSet<Entities.NewTechniqueResult> NewTechniqueResults { get; set; }
    public DbSet<Entities.OppositionReport> OppositionReports { get; set; }
    public DbSet<Entities.ParticipatingOrganization> ParticipatingOrganizations { get; set; }
    public DbSet<Entities.ParticipatingOrganizationKnowledgeAreaBridge> ParticipatingOrganizationKnowledgeAreaBridges { get; set; }
    public DbSet<Entities.Program> Programs { get; set; }
    public DbSet<Entities.ProgramKind> ProgramKinds { get; set; }
    public DbSet<Entities.ProgramExpectResult> ProgramExpectResults { get; set; }
    public DbSet<Entities.ImpactDimension> ImpactDimensions { get; set; }
    public DbSet<Entities.Project> Projects { get; set; }
    public DbSet<Entities.ProjectProgramExpectResultBridge> ProjectProgramExpectResultBridges { get; set; }
    public DbSet<Entities.ProjectImpact> ProjectImpacts { get; set; }
    public DbSet<Entities.ProjectBudgetFunancing> ProjectBudgetFunancings { get; set; }
    public DbSet<Entities.ProjectCategory> ProjectCategories { get; set; }
    public DbSet<Entities.ProjectParticipatingOrganizationBridge> ProjectParticipatingOrganizationBridges { get; set; }
    public DbSet<Entities.ProjectProposal> ProjectProposals { get; set; }
    public DbSet<Entities.ProjectReport> ProjectReports { get; set; }
    public DbSet<Entities.InternalResearcherProjectParticipation> InternalResearcherProjectParticipations { get; set; }
    public DbSet<Entities.ExternalResearcherProjectParticipation> ExternalResearcherProjectParticipations { get; set; }
    public DbSet<Entities.ProjectSpecificObjective> ProjectSpecificObjectives { get; set; }
    public DbSet<Entities.PublicationResult> PublicationResults { get; set; }
    public DbSet<Entities.PublicationResultInternalResearcherBridge> PublicationResultInternalResearcherBridges { get; set; }
    public DbSet<Entities.PublicationResultExternalResearcherBridge> PublicationResultExternalResearcherBridges { get; set; }
    public DbSet<Entities.ResearcherCategory> ResearcherCategories { get; set; }
    public DbSet<Entities.ScientificTechnicalResult> ScientificTechnicalResults { get; set; }
    public DbSet<Entities.ScientificTechnicalResultIntroduction> ScientificTechnicalResultIntroductions { get; set; }
    public DbSet<Entities.ScientificTechnicalResultIntroductionEmployeeBridge> ScientificTechnicalResultIntroductionEmployeeBridges { get; set; }
    public DbSet<Entities.ScientificTechnicalResultKind> ScientificTechnicalResultKinds { get; set; }
    public DbSet<Entities.TeachingCategory> TeachingCategories { get; set; }
    public DbSet<Entities.ThesisResult> ThesisResults { get; set; }
    public DbSet<Entities.ThesisResultInternalResearcherBridge> ThesisResultInternalResearcherBridges { get; set; }
    public DbSet<Entities.ThesisResultExternalResearcherBridge> ThesisResultExternalResearcherBridges { get; set; }
    public DbSet<Entities.TrainingResult> TrainingResults { get; set; }
    public DbSet<Entities.TrainingResultInternalResearcherBridge> TrainingResultInternalResearcherBridges { get; set; }
    public DbSet<Entities.TrainingResultExternalResearcherBridge> TrainingResultExternalResearcherBridges { get; set; }
    public DbSet<Entities.CallForProposal> CallForProposals { get; set; }
    public DbSet<Entities.CallForProposalKnowledgeAreaBridge> CallForProposalKnowledgeAreaBridges { get; set; }
    public DbSet<Entities.CallForProposalDocumentBridge> CallForProposalDocumentBridges { get; set; }
}