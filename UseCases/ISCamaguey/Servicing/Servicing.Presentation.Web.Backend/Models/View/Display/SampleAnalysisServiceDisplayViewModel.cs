namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class SampleAnalysisServiceDisplayViewModel : Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.SampleAnalysisService entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
