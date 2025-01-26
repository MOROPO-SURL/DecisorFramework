namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Display
{
    public class PropertyKindDisplayViewModel : Interop.API.Common.Models.Display.PropertyKindDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.PropertyKind entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
