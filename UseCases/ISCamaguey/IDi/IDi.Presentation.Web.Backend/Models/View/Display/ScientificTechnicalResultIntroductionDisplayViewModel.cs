namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ScientificTechnicalResultIntroductionDisplayViewModel : Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ScientificTechnicalResultIntroduction entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
