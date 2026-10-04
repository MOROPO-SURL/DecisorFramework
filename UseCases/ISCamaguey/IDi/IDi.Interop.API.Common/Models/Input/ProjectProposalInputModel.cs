namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ProjectProposalInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.ProjectProposal, System.Guid>
    {
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

        public override Persistence.Entities.ProjectProposal Export()
        {
            var entity = new Persistence.Entities.ProjectProposal { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.ProjectProposal entity)
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
