namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Display
{
    public class StructureKindDisplayViewModel : Interop.API.Common.Models.Display.StructureKindDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.StructureKind entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
