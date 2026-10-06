namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ThesisResultDisplayViewModel : Interop.API.Common.Models.Display.ThesisResultDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ThesisResult entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
