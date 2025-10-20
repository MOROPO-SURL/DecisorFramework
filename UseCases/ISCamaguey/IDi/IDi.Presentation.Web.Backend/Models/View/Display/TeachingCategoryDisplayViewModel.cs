namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class TeachingCategoryDisplayViewModel : Interop.API.Common.Models.Display.TeachingCategoryDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.TeachingCategory entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
