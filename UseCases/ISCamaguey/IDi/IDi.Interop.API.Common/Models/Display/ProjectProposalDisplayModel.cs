namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ProjectProposalDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ProjectProposal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Title { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public ProgramDisplayModel Program { get; set; }

        public CallForProposalDisplayModel CallForPropousal { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get; set; }

        public virtual void Import(Persistence.Entities.ProjectProposal entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            At = entity.At;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;

            if (entity.Program != null)
            {
                Program = new ProgramDisplayModel();

                Program.Import(entity.Program);
            }

            if (entity.CallForPropousal != null)
            {
                CallForPropousal = new CallForProposalDisplayModel();

                CallForPropousal.Import(entity.CallForPropousal);
            }

            if (entity.Document != null)
            {
                Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                Document.Import(entity.Document);
            }
        }
    }
}
