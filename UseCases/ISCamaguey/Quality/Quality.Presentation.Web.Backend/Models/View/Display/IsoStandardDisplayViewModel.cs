namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Backend.Models.View.Display
{
    public class IsoStandardDisplayViewModel : Interop.API.Common.Models.Display.IsoStandardDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.IsoStandard entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
