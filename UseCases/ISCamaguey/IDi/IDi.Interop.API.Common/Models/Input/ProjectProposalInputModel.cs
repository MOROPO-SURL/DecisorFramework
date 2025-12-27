namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ProjectProposalInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.ProjectProposal, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(5100)]
        public string Description { get; set; }

        public int Priority { get; set; }

        public System.Guid? ProgramId { get; set; }

        public System.Guid? CallForPropousalId { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel Document { get; set; }

        public Persistence.Entities.ProjectProposal Export()
        {
            var entity = new Persistence.Entities.ProjectProposal { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.ProjectProposal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.ProjectProposal entity)
        {
            entity.Title = Title;
            entity.Description = Description;
            entity.Priority = Priority;

            if (entity.ProgramId != ProgramId)
            {
                entity.Program = null;
                entity.ProgramId = ProgramId;
            }

            if (entity.CallForPropousalId != CallForPropousalId)
            {
                entity.CallForPropousal = null;
                entity.CallForPropousalId = CallForPropousalId;
            }
        }
    }
}
