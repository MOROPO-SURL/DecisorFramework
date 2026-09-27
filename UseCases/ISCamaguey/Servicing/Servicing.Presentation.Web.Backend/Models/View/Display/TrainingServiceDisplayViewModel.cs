namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class TrainingServiceDisplayViewModel : Interop.API.Common.Models.Display.TrainingServiceDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.TrainingService entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
