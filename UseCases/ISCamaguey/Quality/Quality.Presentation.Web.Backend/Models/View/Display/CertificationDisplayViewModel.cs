namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Backend.Models.View.Display
{
    public class CertificationDisplayViewModel : Interop.API.Common.Models.Display.CertificationDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Certification entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
