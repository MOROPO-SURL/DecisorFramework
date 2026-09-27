namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class WorkingGroupDisplayViewModel : Interop.API.Common.Models.Display.WorkingGroupDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.WorkingGroup entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
