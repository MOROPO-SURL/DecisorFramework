namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class ResearchSampleDisplayViewModel : Interop.API.Common.Models.Display.ResearchSampleDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ResearchSample entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
