namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Display
{
    public class RequestableServiceDisplayViewModel : Interop.API.Common.Models.Display.RequestableServiceDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.RequestableService entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
