namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class NaturalClientTrainingServiceOrderDisplayViewModel : Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.NaturalClientTrainingServiceOrder entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
