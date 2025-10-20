namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ResearcherCategoryDisplayViewModel : Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ResearcherCategory entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
