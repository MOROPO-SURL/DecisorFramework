namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Display
{
    public class LegalBusinessKindDisplayViewModel : Interop.API.Common.Models.Display.LegalBusinessKindDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.LegalBusinessKind entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
