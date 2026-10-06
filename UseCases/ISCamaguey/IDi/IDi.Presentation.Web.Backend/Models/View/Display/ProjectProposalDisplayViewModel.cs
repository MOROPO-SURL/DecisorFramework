namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ProjectProposalDisplayViewModel : Interop.API.Common.Models.Display.ProjectProposalDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ProjectProposal entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
