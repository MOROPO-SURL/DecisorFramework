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
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(50)]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CategoryId))]
        public ProjectCategory Category { get; set; }
        public System.Guid CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(2550)]
        public string Summary { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(5100)]
        public string Problem { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(5100)]
        public string Context { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(2550)]
        public string Beneficiary { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
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
        public Contract.AbstractResearcher Chief { get; set; }
        public System.Guid ChiefId { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Framework.Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid DocumentId { get; set; }

        public System.Collections.Generic.ICollection<ProjectSpecificObjective> SpecificObjectives { get; set; }

        public System.Collections.Generic.ICollection<ProjectBudgetFunancing> BudgetFunancings { get; set; }

        public System.Collections.Generic.List<ProjectBudgetCurrencyBridge> BudgetCurrencyBridges { get; set; } = new System.Collections.Generic.List<ProjectBudgetCurrencyBridge>();

        public System.Collections.Generic.List<ProjectParticipatingOrganizationBridge> ParticipatingOrganizationBridges { get; set; } = new System.Collections.Generic.List<ProjectParticipatingOrganizationBridge>();

        public System.Collections.Generic.List<ProjectResearcherBridge> ResearcherBridges { get; set; } = new System.Collections.Generic.List<ProjectResearcherBridge>();

    }
}
