namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Backend.Models.View.Display
{
    public class CubanStandardDisplayViewModel : Interop.API.Common.Models.Display.CubanStandardDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.CubanStandard entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
