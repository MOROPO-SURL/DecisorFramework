namespace MOROPO.Framework.Decisor.Essential.Presentation.Web.Backend.Models.View.Display
{
    public class ColaboratorDisplayViewModel : Interop.API.Common.Models.Display.ColaboratorDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Colaborator entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

