namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class LegalClientGroundIntegralStudyServiceOrderDisplayViewModel : Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
