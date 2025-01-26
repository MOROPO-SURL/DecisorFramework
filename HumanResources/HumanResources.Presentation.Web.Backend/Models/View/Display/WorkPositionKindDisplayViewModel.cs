namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Models.View.Display
{
    public class WorkPositionKindDisplayViewModel : Interop.API.Common.Models.Display.WorkPositionKindDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.WorkPositionKind entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
