using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Context.Contract
{
    public interface IIDiDbContext : Domain.Persistence.ORM.EF.Context.Contract.IDomainDbContext, Framework.Decisor.Financial.Persistence.ORM.EF.Context.Contract.IFinancialDbContext
    {
        public DbSet<Entities.AwardKind> AwardKinds { get; set; }
        public DbSet<Entities.AwardResult> AwardResults { get; set; }
        public DbSet<Entities.Extension> Extensions { get; set; }
        public DbSet<Entities.ExternalResearcher> ExternalResearchers { get; set; }
        public DbSet<Entities.Financier> Financiers { get; set; }
        public DbSet<Entities.FinancierResearchAreaBridge> FinancierResearchAreaBridges { get; set; }
        public DbSet<Entities.FinancierDocumentBridge> FinancierDocumentBridges { get; set; }
        public DbSet<Entities.InternalResearcher> InternalResearchers { get; set; }
        public DbSet<Entities.NewTechniqueResult> NewTechniqueResults { get; set; }
        public DbSet<Entities.OppositionReport> OppositionReports { get; set; }
        public DbSet<Entities.ParticipatingOrganization> ParticipatingOrganizations { get; set; }
        public DbSet<Entities.ParticipatingOrganizationResearchAreaBridge> ParticipatingOrganizationResearchAreaBridges { get; set; }
        public DbSet<Entities.Program> Programs { get; set; }
        public DbSet<Entities.ProgramExpectResult> ProgramExpectResults { get; set; }
        public DbSet<Entities.Project> Projects { get; set; }
        public DbSet<Entities.ProjectBudgetCurrencyBridge> ProjectBudgetCurrencyBridges { get; set; }
        public DbSet<Entities.ProjectBudgetFunancing> ProjectBudgetFunancings { get; set; }
        public DbSet<Entities.ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Entities.ProjectParticipatingOrganizationBridge> ProjectParticipatingOrganizationBridges { get; set; }
        public DbSet<Entities.ProjectProposal> ProjectProposals { get; set; }
        public DbSet<Entities.ProjectReport> ProjectReports { get; set; }
        public DbSet<Entities.ProjectResearcherBridge> ProjectResearcherBridges { get; set; }
        public DbSet<Entities.ProjectSpecificObjective> ProjectSpecificObjectives { get; set; }
        public DbSet<Entities.PublicationResult> PublicationResults { get; set; }
        public DbSet<Entities.PublicationResultResearcherBridge> PublicationResultResearcherBridges { get; set; }
        public DbSet<Entities.ResearchArea> ResearchAreas { get; set; }
        public DbSet<Entities.ResearcherCategory> ResearcherCategories { get; set; }    
        public DbSet<Entities.ResearcherResearchAreaDoctorateBridge> ResearcherResearchAreaDoctorateBridges { get; set; }    
        public DbSet<Entities.ResearcherResearchAreaMasteryBridge> ResearcherResearchAreaMasteryBridges { get; set; } 
        public DbSet<Entities.ResearcherResearchAreaSpecializationBridge> ResearcherResearchAreaSpecializationBridges { get; set; }
        public DbSet<Entities.ScientificTechnicalResult> ScientificTechnicalResults { get; set; }
        public DbSet<Entities.ScientificTechnicalResultIntroduction> ScientificTechnicalResultIntroductions { get; set; }
        public DbSet<Entities.ScientificTechnicalResultKind> ScientificTechnicalResultKinds { get; set; }
        public DbSet<Entities.TeachingCategory> TeachingCategories { get; set; }
        public DbSet<Entities.ThesisResult> ThesisResults { get; set; }
        public DbSet<Entities.ThesisResultResearcherBridge> ThesisResultResearcherBridges { get; set; }
        public DbSet<Entities.TrainingResult> TrainingResults { get; set; }
        public DbSet<Entities.TrainingResultResearcherBridge> TrainingResultResearcherBridges { get; set; }
        public DbSet<Entities.CallForPropousal> CallForPropousals { get; set; }
        public DbSet<Entities.CallForPropousalResearchAreaBridge> CallForPropousalResearchAreaBridges { get; set; }
        public DbSet<Entities.CallForPropousalDocumentBridge> CallForPropousalDocumentBridges { get; set; }
    }
}