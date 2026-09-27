namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class LegalClientTrainingServiceOrderDisplayViewModel : Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.LegalClientTrainingServiceOrder entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
