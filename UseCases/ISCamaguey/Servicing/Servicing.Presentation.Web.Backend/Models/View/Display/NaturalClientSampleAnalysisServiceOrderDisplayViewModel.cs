namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class NaturalClientSampleAnalysisServiceOrderDisplayViewModel : Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.NaturalClientSampleAnalysisServiceOrder entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
