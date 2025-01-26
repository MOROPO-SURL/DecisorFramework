namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Models.View.Display
{
    public class SchoolingDisplayViewModel : Interop.API.Common.Models.Display.SchoolingDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Schooling entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
