namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class LegalClientSampleAnalysisServiceOrderDisplayViewModel : Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.LegalClientSampleAnalysisServiceOrder entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
