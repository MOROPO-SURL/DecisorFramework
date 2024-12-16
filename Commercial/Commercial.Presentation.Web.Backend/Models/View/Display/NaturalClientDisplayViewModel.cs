namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Display
{
    public class NaturalClientDisplayViewModel : Interop.API.Common.Models.Display.NaturalClientDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.NaturalClient entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

