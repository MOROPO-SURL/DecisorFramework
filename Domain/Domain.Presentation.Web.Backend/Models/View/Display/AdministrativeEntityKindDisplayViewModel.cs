namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Display
{
    public class AdministrativeEntityKindDisplayViewModel : Interop.API.Common.Models.Display.AdministrativeEntityKindDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.AdministrativeEntityKind entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
