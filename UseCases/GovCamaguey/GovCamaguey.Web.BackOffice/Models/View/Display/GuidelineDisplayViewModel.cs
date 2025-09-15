namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display
{
    public class GuidelineDisplayViewModel : Interop.API.Common.Models.Display.GuidelineDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Prototype.Persistence.Entities.Guideline entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
