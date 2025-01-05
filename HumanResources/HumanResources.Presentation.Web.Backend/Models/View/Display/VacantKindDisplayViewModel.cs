namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Models.View.Display
{
    public class VacantKindDisplayViewModel : Interop.API.Common.Models.Display.VacantKindDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.VacantKind entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
