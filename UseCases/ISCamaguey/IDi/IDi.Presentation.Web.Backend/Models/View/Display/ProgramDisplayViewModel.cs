namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ProgramDisplayViewModel : Interop.API.Common.Models.Display.ProgramDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Program entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
