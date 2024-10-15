namespace MOROPO.Framework.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display
{
    public class ServiceDisplayViewModel : Interop.API.Common.Models.Display.ServiceDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Service entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

