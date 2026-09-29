namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class AssessmentQualityCheckDisplayViewModel : Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.AssessmentQualityCheck entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
