using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class Project : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(500)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(60)]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(60)]
        public string Alias { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CategoryId))]
        public ProjectCategory Category { get; set; }
        public System.Guid CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(5000)]
        public string Summary { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(10000)]
        public string Problem { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(500000)]
        public string Context { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(5000)]
        public string Beneficiary { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(1000)]
        public string MainObjetive { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProgramId))]
        public Program Program { get; set; }
        public System.Guid? ProgramId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProposalId))]
        public ProjectProposal Proposal { get; set; }
        public System.Guid? ProposalId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PredecessorId))]
        public Project Predecessor { get; set; }
        public System.Guid? PredecessorId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ChiefId))]
        public InternalResearcher Chief { get; set; }
        public System.Guid ChiefId { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Framework.Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid DocumentId { get; set; }

        public List<ProjectProgramExpectResultBridge> ProgramExpectResultBridges { get; set; } = new List<ProjectProgramExpectResultBridge>();

        public List<ProjectBudgetCurrencyBridge> BudgetCurrencyBridges { get; set; } = new List<ProjectBudgetCurrencyBridge>();

        public List<ProjectParticipatingOrganizationBridge> ParticipatingOrganizationBridges { get; set; } = new List<ProjectParticipatingOrganizationBridge>();

        public IReadOnlyCollection<InternalResearcherProjectParticipation> InternalResearcherParticipations { get; private set; }

        public IReadOnlyCollection<ExternalResearcherProjectParticipation> ExternalResearcherParticipations { get; private set; }

        public IReadOnlyCollection<ProjectSpecificObjective> SpecificObjectives { get; private set; }

        public IReadOnlyCollection<ProjectBudgetFunancing> BudgetFunancings { get; private set; }

        public IReadOnlyCollection<ProjectImpact> Impacts { get; private set; }

    }
}