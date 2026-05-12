using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ProjectDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Project, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Code { get; set; }

        public ProjectCategoryDisplayModel Category { get; set; }

        public InternalResearcherDisplayModel Chief { get; set; }

        public string Summary { get; set; }

        public string Problem { get; set; }

        public string Context { get; set; }

        public string Beneficiary { get; set; }

        public string MainObjetive { get; set; }

        public ProgramDisplayModel Program { get; set; }

        public ProjectProposalDisplayModel Proposal { get; set; }

        public ProjectDisplayModel Predecessor { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get; set; }

        public System.Collections.Generic.List<ProjectSpecificObjectiveDisplayModel> SpecificObjectives { get; set; } = new System.Collections.Generic.List<ProjectSpecificObjectiveDisplayModel>();

        //public System.Collections.Generic.ICollection<ProjectBudgetFunancing> BudgetFunancings { get; set; }

        //public System.Collections.Generic.List<ProjectBudgetCurrencyBridge> BudgetCurrencyBridges { get; set; } = new System.Collections.Generic.List<ProjectBudgetCurrencyBridge>();

        //public System.Collections.Generic.List<ProjectParticipatingOrganizationBridge> ParticipatingOrganizationBridges { get; set; } = new System.Collections.Generic.List<ProjectParticipatingOrganizationBridge>();

        //public System.Collections.Generic.List<ProjectResearcherBridge> ResearcherBridges { get; set; } = new System.Collections.Generic.List<ProjectResearcherBridge>();

        public void Import(Persistence.Entities.Project entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Alias = entity.Alias;
            Code = entity.Code;
            Summary = entity.Summary;
            Problem = entity.Problem;
            Context = entity.Context;
            Beneficiary = entity.Beneficiary;
            MainObjetive = entity.MainObjetive;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;

            if (entity.Chief != null)
            {
                Chief = new InternalResearcherDisplayModel();

                Chief.Import(entity.Chief);
            }

            if (entity.Category != null)
            {
                Category = new ProjectCategoryDisplayModel();

                Category.Import(entity.Category);
            }

            if (entity.Program != null)
            {
                Program = new ProgramDisplayModel();

                Program.Import(entity.Program);
            }

            if (entity.Proposal != null)
            {
                Proposal = new ProjectProposalDisplayModel();

                Proposal.Import(entity.Proposal);
            }

            foreach (ProjectSpecificObjective item in entity.SpecificObjectives)
            {
                ProjectSpecificObjectiveDisplayModel model = new ProjectSpecificObjectiveDisplayModel();

                model.Import(item);

                SpecificObjectives.Add(model);
            }

            if (entity.Document != null)
            {
                Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                Document.Import(entity.Document);
            }

            // TDOD Predecesor most be inflated from control !!!
        }
    }
}
