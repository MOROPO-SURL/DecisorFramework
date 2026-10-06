namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ProjectDisplayViewModel : Interop.API.Common.Models.Display.ProjectDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Project entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
