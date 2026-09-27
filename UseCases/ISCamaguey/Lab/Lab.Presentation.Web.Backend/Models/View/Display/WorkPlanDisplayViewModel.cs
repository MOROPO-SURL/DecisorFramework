namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class WorkPlanDisplayViewModel : Interop.API.Common.Models.Display.WorkPlanDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.WorkPlan entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
