namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class GroundIntegralStudyServiceDisplayViewModel : Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.GroundIntegralStudyService entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
