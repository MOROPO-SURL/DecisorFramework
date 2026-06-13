using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ProjectInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Project, System.Guid>
    {
        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(60)]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(60)]
        public string Alias { get; set; }

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
        [System.ComponentModel.DataAnnotations.MaxLength(360)]
        public string MainObjetive { get; set; }

        public List<ProjectSpecificObjectiveInputModel> EditionSpecificObjectives { get; set; } = new List<ProjectSpecificObjectiveInputModel>();
        public List<ProjectSpecificObjectiveInputModel> IncomingSpecificObjectives { get; set; } = new List<ProjectSpecificObjectiveInputModel>();
        public List<ProjectSpecificObjectiveDisplayModel> OutgoingSpecificObjectives { get; set; } = new List<ProjectSpecificObjectiveDisplayModel>();

        public List<ParticipatingOrganizationDisplayModel> ParticipatingOrganizations { get; set; } = new List<ParticipatingOrganizationDisplayModel>();

        public List<ProgramExpectResultDisplayModel> ProgramExpectResults { get; set; } = new List<ProgramExpectResultDisplayModel>();

        public List<ProjectBudgetFunancingInputModel> EditionBudgetFunancings { get; set; } = new List<ProjectBudgetFunancingInputModel>();
        public List<ProjectBudgetFunancingInputModel> IncomingBudgetFunancings { get; set; } = new List<ProjectBudgetFunancingInputModel>();
        public List<ProjectBudgetFunancingDisplayModel> OutgoingBudgetFunancings { get; set; } = new List<ProjectBudgetFunancingDisplayModel>();

        public List<InternalResearcherProjectParticipationInputModel> EditionInternalResearcherProjectParticipations { get; set; } = new List<InternalResearcherProjectParticipationInputModel>();
        public List<InternalResearcherProjectParticipationInputModel> IncomingInternalResearcherProjectParticipations { get; set; } = new List<InternalResearcherProjectParticipationInputModel>();
        public List<InternalResearcherProjectParticipationDisplayModel> OutgoingInternalResearcherProjectParticipations { get; set; } = new List<InternalResearcherProjectParticipationDisplayModel>();

        public List<ExternalResearcherProjectParticipationInputModel> EditionExternalResearcherProjectParticipations { get; set; } = new List<ExternalResearcherProjectParticipationInputModel>();
        public List<ExternalResearcherProjectParticipationInputModel> IncomingExternalResearcherProjectParticipations { get; set; } = new List<ExternalResearcherProjectParticipationInputModel>();
        public List<ExternalResearcherProjectParticipationDisplayModel> OutgoingExternalResearcherProjectParticipations { get; set; } = new List<ExternalResearcherProjectParticipationDisplayModel>();

        public System.Guid CategoryId { get; set; }

        public System.Guid? ProgramId { get; set; }

        public System.Guid? ProposalId { get; set; }

        public System.Guid? PredecessorId { get; set; }

        public System.Guid ChiefId { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel Document { get; set; }

        public override Persistence.Entities.Project Export()
        {
            var entity = new Persistence.Entities.Project { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Project entity)
        {
            entity.Priority = Priority;
            entity.Name = Name;
            entity.Code = Code;
            entity.Alias = Alias;
            entity.Summary = Summary;
            entity.Problem = Problem;
            entity.Context = Context;
            entity.Beneficiary = Beneficiary;
            entity.MainObjetive = MainObjetive;
            entity.StartAt = StartAt;
            entity.EndAt = EndAt;

            if (entity.CategoryId != CategoryId)
            {
                entity.Category = null;
                entity.CategoryId = CategoryId;
            }

            if (entity.ProgramId != ProgramId)
            {
                entity.Program = null;
                entity.ProgramId = ProgramId;
            }

            if (entity.ProposalId != ProposalId)
            {
                entity.Proposal = null;
                entity.ProposalId = ProposalId;
            }

            if (entity.PredecessorId != PredecessorId)
            {
                entity.Predecessor = null;
                entity.PredecessorId = PredecessorId;
            }

            if (entity.ChiefId != ChiefId)
            {
                entity.Chief = null;
                entity.ChiefId = ChiefId;
            }

            entity.ParticipatingOrganizationBridges.Clear();

            foreach (var item in ParticipatingOrganizations)
            {
                entity.ParticipatingOrganizationBridges.Add(new Persistence.Entities.ProjectParticipatingOrganizationBridge { ProwId = entity.Id, SternId = item.Id });
            }

            entity.ProgramExpectResultBridges.Clear();

            foreach (var item in ProgramExpectResults)
            {
                entity.ProgramExpectResultBridges.Add(new Persistence.Entities.ProjectProgramExpectResultBridge { ProwId = entity.Id, SternId = item.Id });
            }
        }
    }
}
