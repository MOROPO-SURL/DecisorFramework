namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class NaturalClientGroundIntegralStudyServiceOrderDisplayViewModel : Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
