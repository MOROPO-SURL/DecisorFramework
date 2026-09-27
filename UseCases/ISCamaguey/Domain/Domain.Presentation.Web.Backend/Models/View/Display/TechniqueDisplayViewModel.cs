namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Models.View.Display
{
    public class TechniqueDisplayViewModel : Interop.API.Common.Models.Display.TechniqueDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Technique entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
